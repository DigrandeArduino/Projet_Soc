using ProxyCacheServer;
using RoutingBikes.Proxy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoutingBikes
{
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

        private async Task<SortedDictionary<double, Station>> SortedStations(double[] coordinate)
        {
            JCDecauxItem all_data = GetAllData().Result;
            double distance = 0;
            SortedDictionary<double,Station> stationFind = new SortedDictionary<double,Station>();

            foreach (Station station in all_data.item)
            {
                distance = Math.Sqrt(Math.Pow(station.position.lat-coordinate[0],2) + Math.Pow(station.position.lng-coordinate[1],2));
                try
                {
                    stationFind.Add(distance, station);
                }
                catch (ArgumentException)
                {
                    distance = 0;
                }
            }

            //_finder.Path(a, b);

            return stationFind;
        }

        private async Task<SortedDictionary<double,Station>> DistanceByRoad(Station[] list, double[] coordinate)
        {
            SortedDictionary<double, Station> stationSorted = new SortedDictionary<double, Station>();
            double duration = 0;
            for(int i = 0; i < list.Length; i++)
            {
                duration = _finder.Path(coordinate,new double[2] { list[i].position.lat,list[i].position.lng});
                try
                {
                    stationSorted.Add(duration, list[i]);
                }
                catch (ArgumentException)
                {
                    duration = 0;
                }
            }
            return stationSorted;
        }

        public async Task<Station> FindStation(string Adresse, bool searchBike)
        {
            double[] coordinate = GetCoordinate(Adresse).Result;
            SortedDictionary<double, Station> stationFind = SortedStations(coordinate).Result;
            SortedDictionary<double, Station> sortedByTime = new SortedDictionary<double, Station>();
            Station[] fiveStation = new Station[5];
            bool found = false;

            int i = 0;
            foreach (Station station in stationFind.Values)
            {
                fiveStation[i] = station;
                i++;
                if (i == 5)
                {
                    i = 0;
                    sortedByTime = DistanceByRoad(fiveStation, coordinate).Result;
                    foreach (Station value in sortedByTime.Values)
                    {
                        Service1Client client = new Service1Client();
                        JCDecauxItem stations = client.GetOneContract(value.contract_name);
                        client.Close();
                        foreach (Station value2 in stations.item)
                        {
                            if ((value2.number == value.number && value2.available_bikes > 0 && searchBike) || (value2.number == value.number && value2.available_bike_stands > 0 && !searchBike))
                            {
                                return value2;
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}
