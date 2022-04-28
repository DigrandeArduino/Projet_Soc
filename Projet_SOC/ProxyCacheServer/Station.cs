using System.Runtime.Serialization;

namespace ProxyCacheServer
{
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

    [DataContract]
    public class Position
    {
        [DataMember]
        public double lat { get; set; }
        [DataMember]
        public double lng { get; set; }
    }
}
