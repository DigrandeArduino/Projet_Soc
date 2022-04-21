using System;
using System.ServiceModel;

namespace RoutingBikes
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("RoutingBikes start please wait...");
            Console.WriteLine("SOAP service start please wait...");
            var svc1 = new ServiceHost(typeof(Service1));
            Console.WriteLine("REST service start please wait...");
            var svc2 = new ServiceHost(typeof(Service2));
            svc1.Open();
            svc2.Open();
            Console.WriteLine("RoutingBikes run ! [Press enter to stop]");
            Console.ReadLine();
        }
    }
}