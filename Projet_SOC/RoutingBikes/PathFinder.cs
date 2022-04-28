using System.Net.Http;

namespace RoutingBikes
{
    public class PathFinder
    {
        public Find item { get; set; }
        private readonly HttpClient client = new HttpClient();
        private string key = "5b3ce3597851110001cf62488cc5a239dfcc4cb480cb0a0acb208bd0";

        /*foot-hiking*/
        public double Path(double[] start, double[] end, string typePath)
        {
            string uri = "https://api.openrouteservice.org/v2/directions/" + typePath + "?api_key="+key+"&start=" + start[1].ToString().Replace(",", ".") + "," + start[0].ToString().Replace(",", ".") + "&end=" + end[1].ToString().Replace(",", ".") + "," + end[0].ToString().Replace(",", ".");
            var stringTask = client.GetAsync(uri).Result;
            stringTask.EnsureSuccessStatusCode();
            item = System.Text.Json.JsonSerializer.Deserialize<Find>(stringTask.Content.ReadAsStringAsync().Result);
            return item.features[0].properties.segments[0].duration;
        }
    }
}
