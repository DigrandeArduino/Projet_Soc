using System.ServiceModel;

namespace ProxyCacheServer
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        JCDecauxItem GetAllStation();

        [OperationContract]
        JCDecauxItem GetOneContract(string CacheItemName);
    }
}
