using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Caching;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text.Json;

namespace ProxyCacheServer
{
    [DataContract]
    public class Position
    {
        [DataMember]
        public double lat { get; set; }
        [DataMember]
        public double lng { get; set; }
    }

    [DataContract]
    public class Station
    {
        [DataMember]
        public int number { get; set; }
        [DataMember]
        public string contract_name { get; set; }
        [DataMember]
        public string name { get; set; }
        public string address { get; set; }
        [DataMember]
        public Position position { get; set; }
        public bool banking { get; set; }
        public bool bonus { get; set; }
        [DataMember]
        public int bike_stands { get; set; }
        [DataMember]
        public int available_bike_stands { get; set; }
        [DataMember]
        public int available_bikes { get; set; }
        public string status { get; set; }
        public object last_update { get; set; }
    }

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        JCDecauxItem GetDataFromCache(string CacheItemName);

        [OperationContract]
        JCDecauxItem GetAllStation();

        [OperationContract]
        JCDecauxItem GetOneContract(string CacheItemName);
    }

    public class ProxyCacheGeneric<T>
    {
        private ObjectCache cache;

        public ProxyCacheGeneric()
        {
            cache = MemoryCache.Default;
        }

        public T Get(string CacheItemName)
        {
            if (cache.Contains(CacheItemName))
            {
                return (T)cache.Get(CacheItemName);
            }
            T obj = (T)Activator.CreateInstance(typeof(T), new object[] { CacheItemName });
            cache.Add(CacheItemName, obj, ObjectCache.InfiniteAbsoluteExpiration);
            return obj;
        }

        public T Get(string CacheItemName, double dt_seconds)
        {
            if (cache.Contains(CacheItemName))
            {
                return (T)cache.Get(CacheItemName);
            }
            T obj = (T)Activator.CreateInstance(typeof(T), new object[] { CacheItemName });
            var temp_data = new CacheItemPolicy
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(dt_seconds), //Data remove after dt_seconds secondes

            };
            cache.Add(CacheItemName, obj, temp_data);
            return obj;
        }

        public T Get(string CacheItemName, DateTimeOffset dt)
        {
            if (cache.Contains(CacheItemName))
            {
                return (T)cache.Get(CacheItemName);
            }
            T obj = (T)Activator.CreateInstance(typeof(T), new object[] { CacheItemName });
            var temp_data = new CacheItemPolicy
            {
                AbsoluteExpiration = dt, //Data remove at dt

            };
            cache.Add(CacheItemName, obj, temp_data);
            return obj;
        }
    }

    [DataContract]
    public class JCDecauxItem
    {
        [DataMember]
        public List<Station> item { get; set; }
        private readonly HttpClient client = new HttpClient();
        public JCDecauxItem(String key)
        {
            if(key.Equals("all_data"))
            {
                var stringTask = client.GetStringAsync("https://api.jcdecaux.com/vls/v1/stations?apiKey=f6b6a6117dc8092d548db6238ff42198ec4f2449").Result;
                item = JsonSerializer.Deserialize<List<Station>>(stringTask);
                Console.WriteLine("Get all stations for JCDecaux !");
            }
            else
            {
                var stringTask = client.GetStringAsync("https://api.jcdecaux.com/vls/v1/stations?contract=" + key + "&apiKey=f6b6a6117dc8092d548db6238ff42198ec4f2449").Result;
                /*stringTask.EnsureSuccessStatusCode();*/
                item = JsonSerializer.Deserialize<List<Station>>(stringTask);
                Console.WriteLine("Get all stations for contract : "+key+" !");
            }
        }
    }
}
