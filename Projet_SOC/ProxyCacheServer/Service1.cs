using System;
using System.Threading.Tasks;

namespace ProxyCacheServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private ProxyCacheGeneric<JCDecauxItem> cache = new ProxyCacheGeneric<JCDecauxItem>();
        public JCDecauxItem GetDataFromCache(string CacheItemName)
        {
            if (CacheItemName.Equals("all_data"))
            {
                return cache.Get(CacheItemName);
            }
            return cache.Get(CacheItemName, 30.0);
        }

        public JCDecauxItem GetAllStation()
        {
            return GetDataFromCache("all_data");
        }

        public JCDecauxItem GetOneContract(string CacheItemName)
        {
            return GetDataFromCache(CacheItemName);
        }
    }
}
