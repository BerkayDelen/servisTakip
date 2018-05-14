using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using mapTest.Model;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Xamarin.Forms;
using mapTest.Service;

namespace mapTest
{
    public partial class MainPage : ContentPage
    {
		public  string UserName; 

		private String ActivePage;
        ObservableCollection<Arac_m> araclar = new ObservableCollection<Arac_m>();
		bool twoC = false;

		public MainPage(string UserName)
        {
            InitializeComponent();
			Browser.Source = "http://servistakip.berkaydelen.com/Firebase/index?UserName=delenberkay";
            araclar.Add(new Arac_m(0, "Sefaköy-Tepekent", "34 HG 360"));
            araclar.Add(new Arac_m(1, "Tepekent-Sefaköy", "34 AB 250"));
            araclar.Add(new Arac_m(2, "Sefaköy-Tepekent", "34 DF 310"));
            araclar.Add(new Arac_m(3, "Avcılar-Tepekent", "34 FG 410"));
            AraclarListview.ItemsSource = araclar;
            PageEditor("Location");
			this.UserName = UserName;

			NavigationPage.SetHasNavigationBar(this, false);
            try
            {
                var locator = CrossGeolocator.Current;





                if (locator.IsListening)
                    locator.StopListeningAsync();

                locator.StartListeningAsync(TimeSpan.FromSeconds(3), 0);




                locator.DesiredAccuracy = 25;
                //locator.PositionError += ErrorGeter;

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



        /*
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
        */


        void HomeMenuItem(object sender, EventArgs e)
        {

            PageEditor("MainPage");
        }
        void LocationMenuItem(object sender, EventArgs e)
        {
            PageEditor("Location");
        }
        void ProfileMenuItem(object sender, EventArgs e)
        {
            PageEditor("Profile");
        }


        private void PageEditor(string clickedPage)
        {
            if (clickedPage == "Location")
            {
                ActivePage = "Location";
                Browser.IsVisible = true;
                HomeViewContent.IsVisible = false;
            }
            else if (clickedPage == "MainPage")
            {
                ActivePage = "MainPage";
                Browser.IsVisible = false;
                HomeViewContent.IsVisible = true;
            }
            else if (clickedPage == "Profile")
            {
                ActivePage = "Profile";
            }


            if (ActivePage == "Location")
            {
                LocationMenuImg.Source = "locaitonmenuiconon.png";
                LocationMenuText.TextColor = Color.FromHex("#ff415b");
            }
            else
            {
                LocationMenuImg.Source = "locaitonmenuiconoff.png";
                LocationMenuText.TextColor = Color.FromHex("#323542");
            }

            if (ActivePage == "MainPage")
            {
                HomeMenuImg.Source = "homemenuiconon.png";
                HomeMenuText.TextColor = Color.FromHex("#ff415b");
            }
            else
            {
                HomeMenuImg.Source = "homemenuiconoff.png";
                HomeMenuText.TextColor = Color.FromHex("#323542");
            }

            if (ActivePage == "Profile")
            {
                ProfileMenuImg.Source = "profilemenuiconon.png";
                ProfileMenuText.TextColor = Color.FromHex("#ff415b");
            }
            else
            {
                ProfileMenuImg.Source = "profilemenuiconoff.png";
                ProfileMenuText.TextColor = Color.FromHex("#323542");
            }

        }

        private void UpdatePosition(object sender, PositionEventArgs e)
        {
            //var newPos = new Xamarin.Forms.Maps.Position(e.Position.Latitude, e.Position.Longitude);
           /* DisplayAlert("Konum Değişti",
                         "Accuracy: " + e.Position.Accuracy.ToString() + "\r\n" +
                         "Altitude: " + e.Position.Altitude.ToString() + "\r\n" +
                         "AltitudeAccuracy: " + e.Position.AltitudeAccuracy.ToString() + "\r\n" +
                         "Heading: " + e.Position.Heading.ToString() + "\r\n" +
                         "Speed: " + e.Position.Speed.ToString() + "\r\n" +
                         "Timestamp: " + e.Position.Timestamp + "\r\n" +
                         "listener: " + newPos.Latitude + "\r\n" +
                         "listener: " + newPos.Longitude + "\r\n",
                         "ok"
                        );*/


			if (twoC)
            {
                //DisplayAlert("Durum: Location Mesafe", e.Position.CalculateDistance(new Plugin.Geolocator.Abstractions.Position(e.Position.Latitude, e.Position.Longitude), (Plugin.Geolocator.Abstractions.GeolocatorUtils.DistanceUnits)0.001).ToString(), "OK");


                //DisplayAlert("Durum: Location Update", "Pozisyon Değişti" +, "OK");
                
                    var db = new FirebaseServiceManager();


                    
				db.addUserLocation(new Location
                    {
					Latitude = e.Position.Latitude,
					Longitude = e.Position.Longitude,
                        Time = e.Position.Timestamp.UtcDateTime,
                        Speed = e.Position.Speed,
                        Heading = e.Position.Heading,
                        AltitudeAccuracy = e.Position.AltitudeAccuracy,
                        Altitude = e.Position.Altitude,
                        Accuracy = e.Position.Accuracy
				}, UserName, "0");
                    //DisplayAlert("Durum: Location Ekleme", "Arac Location Eklendi " + value.ToString(), "OK");
                    

                
                twoC = false;
            }
            else
            {
                twoC = true;
            }

        }


    }
}
