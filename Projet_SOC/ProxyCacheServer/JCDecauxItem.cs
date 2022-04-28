using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text.Json;

namespace ProxyCacheServer
{
    [DataContract]
    public class JCDecauxItem
    {
        [DataMember]
        public List<Station> item { get; set; }
        private readonly HttpClient client = new HttpClient();
        public JCDecauxItem(String key)
        {
            if (key.Equals("all_data"))
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
                Console.WriteLine("Get all stations for contract : " + key + " !");
            }
        }
    }
}
