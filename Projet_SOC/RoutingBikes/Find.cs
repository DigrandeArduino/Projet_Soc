namespace RoutingBikes
{
    public class Find
    {
        public Feature2[] features { get; set; }
    }
    public class Feature2
    {
        public Properties2 properties { get; set; }
        public Geometry2 geometry { get; set; }
    }
    public class Geometry2
    {
        public double[][] coordinates { get; set; }
    }
    public class Properties2
    {
        public Segments[] segments { get; set; }
    }
    public class Segments
    {
        public double distance { get; set; }
        public double duration { get; set; }
        public Step[] steps { get; set; }
    }
    public class Step
    {
        public double distance { get; set; }
        public double duration { get; set; }
        public string instruction { get; set; }
    }
}
