using System;
using System.Net;
using System.Text;
using Firebase.Xamarin.Database;
using Firebase.Xamarin.Database.Query;
using mapTest.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace mapTest.Service
{
    public class FirebaseServiceManager
    {
        FirebaseClient fbClient;

        public FirebaseServiceManager(){
            fbClient = new FirebaseClient("https://servistakip-brky.firebaseio.com/");
        }

        public void addData(Arac arac){

            fbClient.Child("Araclar").Child("Arac-2")
                    .PutAsync(arac);
                    

           // while(true){
            /*  
            double latitude = 40.9966957664047;
            double longitude = 28.784877473706629;
                var json  = Newtonsoft.Json.JsonConvert.SerializeObject(
                    new {
                        latitude = latitude,
                        longitude = longitude,

                    }
                );

                var request = WebRequest.CreateHttp("https://servistakip-brky.firebaseio.com/Araclar.json");
                request.Method = "POST";
                request.ContentType = "application/json";

                var buffer = Encoding.UTF8.GetBytes(json);
                */
           // }
        }

		public void addUser(User user,string UserName)
        {

			fbClient.Child("Users").Child(UserName)
			        .PutAsync(user);

   
        }

        public async void addLocation(Location location,String Key,String Child){

            await  fbClient.Child("Araclar")
                          .Child(Key)
                          .Child("location").Child(Child).PutAsync(location);
                                     
            
        }

		public async void addUserLocation(Location location, String UserName, String Child)
        {

            await fbClient.Child("Users")
			              .Child(UserName)
                          .Child("location").Child(Child).PutAsync(location);


        }

        public async Task<List<Arac>> GetAraclar(){

            var list = (await fbClient.Child("Araclar")

                                       .OnceAsync<Arac>())
                .Select(item => new Arac
                {
                    Key = item.Key,
                    ID = item.Object.ID,
                location = item.Object.location.ToList(),
                    Plaka = item.Object.Plaka,
                }).ToList();
            
            /*List<Arac> araclar = new List<Arac>();
           
            foreach (var item in list)
            {
                List<Location> locations = new List<Location>();
                foreach (var locationitem in item.Object.location)
                {
                    locations.Add(new Location
                    {
                        Latitude = locationitem.Latitude,
                        longitude = locationitem.longitude
                    });
                }

                araclar.Add(new Arac
                {
                    ID = item.Object.ID,
                    location =  locations,
                    Plaka = item.Object.Plaka,

                });
            }*/
           


            return list;
        }

    }
}
