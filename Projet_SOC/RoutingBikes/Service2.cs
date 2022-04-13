using ProxyCacheServer;
using System;
using System.Text.Json;

namespace RoutingBikes
{
    public class Service2 : IService2
    { 
        private Service1 _service = new Service1();
        public string GetTheStation(string adresse, string searchBike)
        {
            Station station = _service.FindStation(adresse, searchBike).Result;
            string answer = JsonSerializer.Serialize(station);
            return answer;
        }
    }
}
