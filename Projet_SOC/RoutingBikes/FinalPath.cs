using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
