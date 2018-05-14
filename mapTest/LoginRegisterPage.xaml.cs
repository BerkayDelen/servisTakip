using System;
using System.Collections.Generic;
using mapTest.Model;
using Xamarin.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;
using mapTest.Service;

namespace mapTest
{
    public partial class LoginRegisterPage : ContentPage
    {
        
		public string uri = "http://servistakip.berkaydelen.com";
        public string register = "/User/add";
        public string login = "/User/login";

		public LoginRegisterPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void OpenRegisterLayout(object sender, EventArgs e)
        {
            LoginLayout.IsVisible = false;

            RegisterLayout.IsVisible = true;

        }
        private async void OpenLoginLayout(object sender, EventArgs e)
        {
            LoginLayout.IsVisible = true;

            RegisterLayout.IsVisible = false;
        }

        private async void Register(object sender, EventArgs e)
        {
            /* string sUrl = "your server url";
             string sContentType = "application/json"; // or application/xml
             JObject oJsonObject = new JObject();
             oJsonObject.Add("any key", "data");
             HttpClient oHttpClient = new HttpClient();
             var oTaskPostAsync = oHttpClient.PostAsync(sUrl, new StringContent(oJsonObject.ToString(), Encoding.UTF8, sContentType));
             oTaskPostAsync.ContinueWith((oHttpResponseMessage) =>
             {
             });*/
            /*
             * 
             * var client = new HttpClient();
            client.BaseAddress = new Uri(uri);
            string jsonData = @"{""Name"" : ""Berkay Deneme"", ""Surname"" : ""Delen Deneme"" , ""Authority_Id"" : ""0""}";
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(register, content);
            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
            var result = await response.Content.ReadAsStringAsync();
            await DisplayAlert( uri + register, result, "OK");
    */

            Success_m succes = await service_register(Register_Name.Text, Register_Surname.Text, Register_UserName.Text, Register_Password.Text);
            if (succes.Succes)
            {
				var db = new FirebaseServiceManager();
				db.addUser(new User
                {
                    location = new List<Location>{
                    new Location{
                    Latitude=0,
                        Longitude=0,

                    }
					}},Register_UserName.Text);


				await Navigation.PushAsync(new MainPage(Register_UserName.Text));
            }
            else
            {
                await DisplayAlert(uri + register, "Error : " + succes.Error, "OK");
            }
            // string json = JsonConvert.SerializeObject();


        }

        private async void Login(object sender, EventArgs e)
        {
            Success_m succes = await service_login(lgn_UserName.Text, lgn_Password.Text);
            if (succes.Succes)
            {
				
				Navigation.PushAsync(new MainPage(lgn_UserName.Text));

            }
            else
            {
                await DisplayAlert(uri + register, "Error : " + succes.Error, "OK");
            }
        }


        private async Task<Success_m> service_register(string Name, string Surname, string UserName, string password)
        {

            var tokenJson = "";
            var client = new HttpClient();
            //await DisplayAlert("test", JsonConvert.SerializeObject(new { Name = "BErkay test device", Surname = "Deleen", Authority_Id = "0" }), "WTTF");
            //StringContent str = new StringContent("Name=berkayS&Surname=delenS&Authority_Id=0", Encoding.UTF8, "application/x-www-form-urlencoded");
            var content = new StringContent("Name=" + Name + "&Surname=" + Surname + "&UserName=" + UserName + "&Password=" + password + "&Authority_Id=0", Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await client.PostAsync(uri + register, content);

            if (response.IsSuccessStatusCode)
            {
                tokenJson = await response.Content.ReadAsStringAsync();
            }
            Success_m succes = JsonConvert.DeserializeObject<Success_m>(tokenJson);
            return succes;

        }

        private async Task<Success_m> service_login(string Username, string Password)
        {

            var tokenJson = "";
            var client = new HttpClient();
            //await DisplayAlert("test", JsonConvert.SerializeObject(new { Name = "BErkay test device", Surname = "Deleen", Authority_Id = "0" }), "WTTF");
            //StringContent str = new StringContent("Name=berkayS&Surname=delenS&Authority_Id=0", Encoding.UTF8, "application/x-www-form-urlencoded");
            var content = new StringContent("UserName=" + Username + "&Password=" + Password + "", Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await client.PostAsync(uri + login, content);

            if (response.IsSuccessStatusCode)
            {
                tokenJson = await response.Content.ReadAsStringAsync();
            }
            Success_m succes = JsonConvert.DeserializeObject<Success_m>(tokenJson);
            return succes;


        }



    }
}
