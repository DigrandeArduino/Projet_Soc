using ProxyCacheServer;
using RoutingBikes.Proxy;
using System;
using System.Threading.Tasks;

namespace RoutingBikes
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public async Task<string> GetData(int value)
        {
            Service1Client client = new Service1Client();
            JCDecauxItem stations = client.GetAllStation();
            client.Close();

            return string.Format("You entered");
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
