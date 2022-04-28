using System.ServiceModel;
using System.Threading.Tasks;
using System.Net.Http;
using ProxyCacheServer;

namespace RoutingBikes
{
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
        Task<Station> FindStation(string adresse, bool searchBike, bool isCoord);
    }
}
