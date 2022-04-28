using System.Net.Http;

namespace RoutingBikes
{
    public class Finder
    {
        private Reponse item { get; set; }
        private readonly HttpClient client = new HttpClient();
        private string key = "5b3ce3597851110001cf62488cc5a239dfcc4cb480cb0a0acb208bd0";

        private void SetPosition(string adresse)
        {
            adresse = adresse.Replace(" ", "+");
            var stringTask = client.GetAsync("https://api.openrouteservice.org/geocode/search?api_key="+key+"&text=" + adresse).Result;
            stringTask.EnsureSuccessStatusCode();
            item = System.Text.Json.JsonSerializer.Deserialize<Reponse>(stringTask.Content.ReadAsStringAsync().Result);
        }

        public double[] GetCoord(string adresse)
        {
            SetPosition(adresse);
            return new double[2] { item.features[0].geometry.coordinates[1], item.features[0].geometry.coordinates[0] };
        }
    }
}
