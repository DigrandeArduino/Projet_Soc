using ServiceReference1;

namespace ClientLourd
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("CLIENT LOURD :\nExemple de fonction :\n");
            string stop = "n";
            while (!stop.Equals("stop"))
            {
                Service1Client client = new Service1Client();
                Console.WriteLine("Destination :\n");
                string adresse = Console.ReadLine();
                DateTime start = DateTime.Now;
                Console.WriteLine("Wait execution...");
                Station station = client.FindStationAsync(adresse, true, false).Result;
                Console.WriteLine("Execution time 1 : "+DateTime.Now.Subtract(start).ToString()+"s\n");
                start = DateTime.Now;
                station = client.FindStationAsync(adresse, true, false).Result;
                Console.WriteLine("Execution time 2 : "+DateTime.Now.Subtract(start).ToString()+"s\n");
                start = DateTime.Now;
                station = client.FindStationAsync(adresse, true, false).Result;
                Console.WriteLine("Execution time 3 : " + DateTime.Now.Subtract(start).ToString() + "s\n");
                Console.WriteLine("Continuer ? [stop]");
                stop = Console.ReadLine();
            }

            /*CalculatorSoapClient client = new CalculatorSoapClient(new CalculatorSoapClient.EndpointConfiguration());*/
            /*int result = await client.AddAsync(5, 2);
            Console.WriteLine(result);*/
            /*
             * Client lourd :
             * fonctionnalité : stat ? stat d'utilisation du serveur rest/soap
             * autre truc : test de perf : temps de requète pour le serveur : fait des requète de test de distance
             * Justifier le test : pk le faire sur client lourd ?
             */
        }
    }
}
