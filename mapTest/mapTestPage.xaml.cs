using System;
using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using mapTest.Service;
using mapTest.Model;
using System.Diagnostics;
using Plugin.Geolocator.Abstractions;


namespace mapTest
{
    public partial class mapTestPage : ContentPage
    {
        Map currentMap;

        RootObject rootObject = new RootObject();

        int timer = 0;
        int value = 0;

        Arac myArac = new Arac();

        bool twoC = false;

        public mapTestPage()
        {
            InitializeComponent();
           
           
            Browser.Source = "http://servistakip.berkaydelen.com/";
           
           // customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(40.997280, 28.791912), Distance.FromMiles(1.0)));
         /*   Device.StartTimer(TimeSpan.FromSeconds(10), () =>
            {
                Task.Run(async () =>
                {
                    if(myArac.ID !=0){
                        var db = new FirebaseServiceManager();

                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 50;
                    var pos = await locator.GetPositionAsync(TimeSpan.FromSeconds(100));
                        // la.Text = timer + " Latitude: " + pos.Latitude.ToString();
                        // lo.Text = timer + " Longitude: " + pos.Longitude.ToString();
                        value++;
                        db.addLocation(new Location { Latitude = pos.Latitude, Longitude = pos.Longitude }, myArac.Key,value.ToString());
                        await DisplayAlert("Durum: Location Ekleme", "Arac Location Eklendi "+value.ToString(), "OK");
                    timer++;

                    }
                });
                return true;
            });

*/


        }

        async void Arac_Ekle(object sender, System.EventArgs e)
        {
            var db = new FirebaseServiceManager();
            db.addData(new Arac{
                ID = 155,
                location = new List<Location>{
                    new Location{
                    Latitude=40.996699,
                        Longitude=28.784876,

                    }
                },
                Plaka = "34 FR 34"

            });
            await DisplayAlert("Durum: Ekleme", "Arac Eklendi", "OK");
        }

        async void AraclarList(object sender, System.EventArgs e)
        {
            
            /*var db = new FirebaseServiceManager();

            var list = await  db.GetAraclar();

            if(list != null){
                foreach (var item in list)
                {

                    await DisplayAlert("ok", "ID: " + item.ID + "\n Locations Count: " + item.location.Count + "\n Plaka: " + item.Plaka, "acc");
                }
            }*/

            var db = new FirebaseServiceManager();
            var list = await db.GetAraclar();

            if (list != null)
            {
                foreach (var item in list)
                {
                    if (item.ID == 155)
                    {
                        myArac = new Arac
                        {
                            Key = item.Key,
                            ID = item.ID,
                            location = item.location,
                            Plaka = item.Plaka,
                        };

                        value = item.location.Count-1;
                       
                        await DisplayAlert("Durum: Location Ekleme", "Arac Location Eklendi"+value, "OK");
                    }


                }
            }

           
        }

        protected override async void OnAppearing()
        {
           /* await DisplayAlert("ok", "AÇıldı Mı ?", "acc");
            string url = "https://roads.googleapis.com/v1/snapToRoads?path=40.996699, 28.784876|40.997232, 28.786818|40.997533, 28.788129|40.997289, 28.790009|40.997200, 28.790893|40.996774, 28.791718|41.000256, 28.793213|40.999952,28.796530&interpolate=true&key=AIzaSyDc205f8h48tUhUZCcrGk6PF9b1P88g1Og";
            JSValue json = await FetchWeatherAsync(url);
*/
            await DisplayAlert("ok", "Açıldı", "acc");
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            //throw new System.NotImplementedException();
           /* var locator = CrossGeolocator.Current;

           /* if (locator.IsListening)
            {
                await locator.StopListeningAsync();
            }*/

           /* if (locator.IsGeolocationAvailable)
            {
                
                locator.DesiredAccuracy = 25;

                await locator.StartListeningAsync(TimeSpan.FromSeconds(3), 5);
            }
            else
            {
                await locator.StartListeningAsync(TimeSpan.FromSeconds(3), 5);
            }


           
             

            var pos = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            Debug.WriteLine("Position Status: {0}", pos.Timestamp);
            Debug.WriteLine("Position Latitude: {0}", pos.Latitude);
            Debug.WriteLine("Position Longitude: {0}", pos.Longitude);






            la.Text = "Latitude: " + pos.Latitude.ToString();
            lo.Text = "Longitude: " + pos.Longitude.ToString();
*/
            /* var pin = new CustomPin
             {
                 Type = PinType.Place,
                 Position = new Position(37.79752, -122.40183),
                 Label = "Xamarin San Francisco Office",
                 Address = "394 Pacific Ave, San Francisco CA",
                 Id = "Xamarin",
                 Url = "http://xamarin.com/about/"
             };*/
            
           /* var pin = new Pin()
            {
                Position = new Xamarin.Forms.Maps.Position(pos.Latitude, pos.Longitude),
                Label = "Berkay Delen"

            };*/

            /*
            MyMap.Pins.Add(pin);

           
            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(pos.Latitude, pos.Longitude), Distance.FromMeters(10)));*/

           // locator.PositionChanged += UpdatePosition;


            try
            {
                var locator = CrossGeolocator.Current;





                if (locator.IsListening)
                    await locator.StopListeningAsync();

                await locator.StartListeningAsync(TimeSpan.FromSeconds(3), 0);


                   

                locator.DesiredAccuracy = 25;
                locator.PositionError += ErrorGeter;

               // var gpsPositionTask = locator.GetPositionAsync(TimeSpan.FromSeconds(10));

               
               



               // var gpsPosition = await gpsPositionTask;
               // var position = new Plugin.Geolocator.Abstractions.Position(gpsPosition.Latitude, gpsPosition.Longitude);



                locator.PositionChanged += UpdatePosition;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("exc: " + ex.Message);

            }
           
        }

        async void Handle_Clicked_1(object sender, System.EventArgs e)
        {
           /* customMap.RouteCoordinates.Add(new Position(40.996699, 28.784876));
            customMap.RouteCoordinates.Add(new Position(40.997232, 28.786818));
            customMap.RouteCoordinates.Add(new Position(40.997533, 28.788129));
            customMap.RouteCoordinates.Add(new Position(40.997289, 28.790009));
            customMap.RouteCoordinates.Add(new Position(40.997200, 28.790893));
            customMap.RouteCoordinates.Add(new Position(40.996774, 28.791718));
            customMap.RouteCoordinates.Add(new Position(41.000256, 28.793213));
            customMap.RouteCoordinates.Add(new Position(40.999952, 28.796530));


            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(40.997280, 28.791912), Distance.FromMiles(1.0)));


            await DisplayAlert("ok", "Listelendi", "acc");*/

        }

        public void CreateMap(){
            currentMap = new Map
            {
                MapType = MapType.Street,

            };

            Content = currentMap;
        }



      



        public class SnappedPoint
        {
            public Location location { get; set; }
            public int originalIndex { get; set; }
            public string placeId { get; set; }
        }
        public class RootObject
        {
            public List<SnappedPoint> snappedPoints { get; set; }
        }

       

        private  void UpdatePosition(object sender, PositionEventArgs e)
        {
            var newPos = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
            label_Accuracy.Text = "Accuracy: " + e.Position.Accuracy.ToString();
            label_Altitude.Text = "Altitude: " + e.Position.Altitude.ToString();
            label_AltitudeAccuracy.Text = "AltitudeAccuracy: " + e.Position.AltitudeAccuracy.ToString();
            label_Heading.Text = "Heading: " + e.Position.Heading.ToString();
            label_Speed.Text = "Speed: " + e.Position.Speed.ToString();
            label_Timestamp.Text = "Timestamp: " + e.Position.Timestamp;
            la.Text = "listener: " + newPos.Latitude;
            lo.Text = "listener: " + newPos.Longitude;
            if(twoC){
                //DisplayAlert("Durum: Location Mesafe", e.Position.CalculateDistance(new Plugin.Geolocator.Abstractions.Position(e.Position.Latitude, e.Position.Longitude), (Plugin.Geolocator.Abstractions.GeolocatorUtils.DistanceUnits)0.001).ToString(), "OK");


                //DisplayAlert("Durum: Location Update", "Pozisyon Değişti" +, "OK");
                if (myArac.ID != 0)
                {
                    var db = new FirebaseServiceManager();


                    value++;
                    db.addLocation(new Location
                    {
                        Latitude = newPos.Latitude,
                        Longitude = newPos.Longitude,
                        Time = e.Position.Timestamp.UtcDateTime,
                        Speed = e.Position.Speed,
                        Heading = e.Position.Heading,
                        AltitudeAccuracy = e.Position.AltitudeAccuracy,
                        Altitude = e.Position.Altitude,
                        Accuracy = e.Position.Accuracy
                    }, myArac.Key, value.ToString());
                    //DisplayAlert("Durum: Location Ekleme", "Arac Location Eklendi " + value.ToString(), "OK");
                    timer++;

                }
                else
                {
                    DisplayAlert("Durum: Location Hata", "ARAC YOK", "OK");
                }
                twoC = false;
            }else{
                twoC = true;
            }

        }
        private void ErrorGeter(object sender, EventArgs e){
            DisplayAlert("Durum: Location Hata", "Hata:"+e.ToString(), "OK");
        }
       
    }

}
