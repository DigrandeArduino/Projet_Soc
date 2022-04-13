using System.ServiceModel;
using System.Threading.Tasks;
using System.Net.Http;
using ProxyCacheServer;
using System.ServiceModel.Web;

namespace RoutingBikes
{
    internal class Reponse
    {
        public Feature[] features { get; set; }
    }

    internal class Feature
    {
        public Geometry geometry { get; set; }

        public Properties properties { get; set; }
    }

    internal class Properties
    {

    }

    internal class Geometry
    {
        public double[] coordinates { get; set; }
    }

    internal class Find
    {
        public Feature2[] features { get; set; }
    }

    internal class Feature2
    {
        public Properties2 properties { get; set; }
    }

    internal class Properties2
    {
        public Segments[] segments { get; set; }
    }
    internal class Segments
    {
        public double distance { get; set; }
        public double duration { get; set; }
    }

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Task<JCDecauxItem> GetAllData();

        [OperationContract]
        Task<JCDecauxItem> GetContract(string Contract);

        [OperationContract]
        Task<double[]> GetCoordinate(string Adresse);

        [OperationContract]
        /*[WebInvoke(
            UriTemplate = "/default?adresse={adresse}&searchBike={searchBike}",
            BodyStyle = WebMessageBodyStyle.Bare)]*/
        Task<Station> FindStation(string adresse, string searchBike);
    }

    public class Finder
    {
        private Reponse item { get; set; }
        private readonly HttpClient client = new HttpClient();

        private void SetPosition(string adresse)
        {
            adresse = adresse.Replace(" ", "+");
            var stringTask = client.GetStringAsync ("https://api.openrouteservice.org/geocode/search?api_key=5b3ce3597851110001cf62488cc5a239dfcc4cb480cb0a0acb208bd0&text="+adresse).Result;
            item = System.Text.Json.JsonSerializer.Deserialize<Reponse>(stringTask);
        }

        public double[] GetCoord(string adresse)
        {
            SetPosition(adresse);
            return new double[2] { item.features[0].geometry.coordinates[1], item.features[0].geometry.coordinates[0] };
        }
    }

    public class PathFinder
    {
        private Find item { get; set; }
        private readonly HttpClient client = new HttpClient();

        public double Path(double[] start, double[] end)
        {
            string uri = "https://api.openrouteservice.org/v2/directions/foot-hiking?api_key=5b3ce3597851110001cf62488cc5a239dfcc4cb480cb0a0acb208bd0&start=" + start[1].ToString().Replace(",",".") + "," + start[0].ToString().Replace(",", ".") + "&end=" + end[1].ToString().Replace(",", ".") + "," + end[0].ToString().Replace(",", ".");
            var stringTask = client.GetStringAsync(uri).Result;
            item = System.Text.Json.JsonSerializer.Deserialize<Find>(stringTask);
            return item.features[0].properties.segments[0].duration;
        }
    }
}
