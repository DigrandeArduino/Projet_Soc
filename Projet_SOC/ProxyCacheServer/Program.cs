using System;
using System.ServiceModel;

namespace ProxyCacheServer
{
    internal class Program
    {
        public static void Main()
        {
            Console.WriteLine("ProxyCacheServer start please wait...");
            var svc = new ServiceHost(typeof(Service1));
            svc.Open();
            Console.WriteLine("ProxyCacheServer run ! [Press enter to stop]");
            Console.ReadLine();
        }
    }
}