namespace RoutingBikes
{
    public class Reponse
    {
        public Feature[] features { get; set; }
    }
    public class Feature
    {
        public Geometry geometry { get; set; }

        public Properties properties { get; set; }
    }
    public class Properties
    {

    }
    public class Geometry
    {
        public double[] coordinates { get; set; }
    }

}