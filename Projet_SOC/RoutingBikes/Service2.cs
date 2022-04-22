using ProxyCacheServer;
using System;
using System.Globalization;
using System.Text.Json;

namespace RoutingBikes
{
    public class FinalPath
    {
        public double[] startCoord { get; set; }
        public double[] startStationCoord { get; set; }
        public double[] endStationCoord { get; set; }
        public double[] endCoord { get; set; }
        public double[][] pathStartToStation { get; set; }
        public Step[] startStep { get; set; }
        public double[][] pathBikeToStation { get; set; }
        public Step[] bikeStep { get; set; }
        public double[][] pathStartToEnd { get; set; }
        public Step[] endStep { get; set; }
        public string footIsBetter { get; set; }
        public double total_time { get; set; }  
    }

    public class Service2 : IService2
    { 
        private Service1 _service = new Service1();
        private Finder _finder = new Finder();
        private PathFinder _pathFinder = new PathFinder();
        public string GetTheStation(string adresse, string searchBike, string isCoord)
        {
            Station station = _service.FindStation(adresse, searchBike.Equals("yes"), isCoord.Equals("yes")).Result;
            string answer = JsonSerializer.Serialize(station);
            return answer;
        }

        public FinalPath GetFinalPath(string start, string end, string isCoord)
        {
            if(start == null || start=="" || end == null || end == null)
            {
                Console.WriteLine("Start or end destination are null !");
                return null;
            }
            Console.WriteLine("Find a path...");
            try
            {
                double[] coord_start = new double[] { 0, 0 };
                double total_time = 0;
                if (isCoord.Equals("yes"))
                {
                    NumberFormatInfo provider = new NumberFormatInfo();
                    provider.NumberDecimalSeparator = ".";
                    var temp = start.Split(',');
                    coord_start = new double[] { Convert.ToDouble(temp[0], provider), Convert.ToDouble(temp[1], provider) };
                }
                else
                {
                    coord_start = _finder.GetCoord(start);
                }
                double[] coord_end = _finder.GetCoord(end);
                Station station_start = _service.FindStation(start, true, isCoord.Equals("yes")).Result;
                Station station_end = _service.FindStation(end, false, false).Result;
                FinalPath path = new FinalPath();
                path.startCoord = coord_start;
                path.endCoord = coord_end;
                path.startStationCoord = new double[] { station_start.position.lat, station_start.position.lng };
                path.endStationCoord = new double[] { station_end.position.lat, station_end.position.lng };

                _pathFinder.Path(path.startCoord, path.startStationCoord, "foot-walking");
                path.pathStartToStation = _pathFinder.item.features[0].geometry.coordinates;
                path.startStep = _pathFinder.item.features[0].properties.segments[0].steps;
                total_time += _pathFinder.item.features[0].properties.segments[0].duration;

                _pathFinder.Path(path.startStationCoord, path.endStationCoord, "cycling-regular");
                path.pathBikeToStation = _pathFinder.item.features[0].geometry.coordinates;
                path.bikeStep = _pathFinder.item.features[0].properties.segments[0].steps;
                total_time += _pathFinder.item.features[0].properties.segments[0].duration;

                _pathFinder.Path(path.endStationCoord, path.endCoord, "foot-walking");
                path.pathStartToEnd = _pathFinder.item.features[0].geometry.coordinates;
                path.endStep = _pathFinder.item.features[0].properties.segments[0].steps;
                total_time += _pathFinder.item.features[0].properties.segments[0].duration;

                //Check if travel by foot is better :
                _pathFinder.Path(path.startCoord, path.endCoord, "foot-walking");
                if (total_time >= _pathFinder.item.features[0].properties.segments[0].duration)
                {
                    path.footIsBetter = "yes";
                    path.pathStartToStation = _pathFinder.item.features[0].geometry.coordinates;
                    path.startStep = _pathFinder.item.features[0].properties.segments[0].steps;
                    path.total_time = _pathFinder.item.features[0].properties.segments[0].duration;
                    Console.WriteLine("Foot path is better !");
                }

                else
                {
                    path.footIsBetter = "no";
                    path.total_time = total_time;
                    Console.WriteLine("Bike path is better !");
                }
                return path;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in OpenRouteServices, too many request ! Please wait !");
                return null;
            }
        }
    }
}
