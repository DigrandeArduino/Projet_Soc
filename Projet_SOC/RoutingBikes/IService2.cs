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
                UriTemplate = "/getStation?adresse={adresse}&searchBike={searchBike}",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json)]
        string GetTheStation(string adresse, string searchBike);
    }

}
