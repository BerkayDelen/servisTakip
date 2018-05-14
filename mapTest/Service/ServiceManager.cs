using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using mapTest.Model;
using Newtonsoft.Json;
using System.Collections;


namespace mapTest.Service
{
    public class ServiceManager
    {
        private string url = "https://roads.googleapis.com/v1/snapToRoads?path=40.996699,%2028.784876|40.997232,%2028.786818|40.997533,%2028.788129|40.997289,%2028.790009|40.997200,%2028.790893|40.996774,%2028.791718|41.000256,%2028.793213|40.999952,28.796530&interpolate=true&key=AIzaSyDc205f8h48tUhUZCcrGk6PF9b1P88g1Og";
        
        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public async Task GetAll(){
            HttpClient client = await GetClient();

            var result = await client.GetStringAsync(url);
            var mobileResult = result.ToString();
            var persons = JsonConvert.DeserializeObject<SnappedPoint>(result);



        }

        public class Location
        {
            public double latitude { get; set; }
            public double longitude { get; set; }
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
    }
}
