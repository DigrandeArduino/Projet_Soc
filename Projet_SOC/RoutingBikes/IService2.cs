using System.ServiceModel;
using System.ServiceModel.Web;

namespace RoutingBikes
{
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        [WebInvoke(
                Method = "GET",
                UriTemplate = "/getStation?adresse={adresse}&searchBike={searchBike}&isCoord={isCoord}",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        string GetTheStation(string adresse, string searchBike, string isCoord);

        [OperationContract]
        [WebInvoke(
            Method = "GET",
            UriTemplate = "/getPath?start={start}&end={end}&isCoord={isCoord}",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        FinalPath GetFinalPath(string start, string end, string isCoord);
    }

}
