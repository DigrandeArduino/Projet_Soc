using System.ServiceModel;

namespace ProxyCacheServer
{
    [ServiceContract]
    public interface IProxyCache
    {
        [OperationContract]
        JCDecauxItem GetAllStation();

        [OperationContract]
        JCDecauxItem GetOneContract(string CacheItemName);
    }
}
