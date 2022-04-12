using ProxyCacheServer;
using RoutingBikes.Proxy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoutingBikes
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private Finder _binder = new Finder();
        private PathFinder _finder = new PathFinder();
        public async Task<JCDecauxItem> GetAllData()
        {
            Service1Client client = new Service1Client();
            JCDecauxItem stations = client.GetAllStation();
            client.Close();
            return stations;
        }

        public async Task<JCDecauxItem> GetContract(string Contract)
        {
            Service1Client client = new Service1Client();
            JCDecauxItem stations = client.GetOneContract(Contract);
            client.Close();
            return stations;
        }

        public async Task<double[]> GetCoordinate(string Adresse)
        {
            return _binder.GetCoord(Adresse);
        }

        public async Task<double[]> FindStation(string Adresse)
        {
            JCDecauxItem all_data = GetAllData().Result;
            double[] coordinate = GetCoordinate(Adresse).Result;

            double distance = 0;
            double old = 9999999999;
            List<Station> stationFind = new List<Station>();
            foreach(Station station in all_data.item)
            {
                distance = Math.Sqrt(Math.Pow(station.position.lat-coordinate[0],2) + Math.Pow(station.position.lng-coordinate[1],2));
                if(distance < old)
                {
                    old = distance;
                    stationFind.Add(station);
                }
            }

            //_finder.Path(a, b);

            /*
             * HERE do the new algo de trie pour les stations a demain :) 
             */

            int i = 0;
            return new double[] {0,0};
        }
    }
}
