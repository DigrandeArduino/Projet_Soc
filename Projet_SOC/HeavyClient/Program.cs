using ServiceReference1;

namespace ClientLourd
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("CLIENT LOURD :\nExemple de fonction :\n");
            string stop = "n";
            string choice = "1";
            while (!stop.Equals(""))
            {
                Console.WriteLine("Choice a function :\n1 - Test destination finder performance\n2 - Compare destination performance\n");
                choice = Console.ReadLine();
                Console.WriteLine(" ");
                if(choice == "1")
                {
                    Destination();
                }
                else if(choice == "2")
                {
                    ComparePerf();
                }
                else
                {
                    Console.WriteLine("No function found...");
                }
                Console.WriteLine("\nContinuer ? [enter to stop]");
                stop = Console.ReadLine();
                Console.WriteLine(" ");
            }
        }

        static async Task Destination()
        {
            Service1Client client = new Service1Client();
            Console.WriteLine("Destination :\n");
            string adresse = Console.ReadLine();
            DateTime start = DateTime.Now;
            DateTime total = DateTime.Now;
            Console.WriteLine("Wait execution...\n");
            Station station;
            for (int i = 0; i < 3; i++)
            {
                start = DateTime.Now;
                station = client.FindStationAsync(adresse, true, false).Result;
                Console.WriteLine("Execution time "+i.ToString()+" : " + DateTime.Now.Subtract(start).ToString() + "s");
                if (station == null)
                {
                    Console.WriteLine("STATION NULL");
                }
            }
            Console.WriteLine("Number of request : 3");
            Console.WriteLine("Total time : " + DateTime.Now.Subtract(total).ToString() + "s");
            client.Close();
        }

        static async Task ComparePerf()
        {
            Service1Client client = new Service1Client();
            Console.WriteLine("Enter some adresse separate by '&' :");
            Console.WriteLine(" ");
            string input = Console.ReadLine();
            Console.WriteLine(" ");
            string[] adresse = input.Split('&');
            DateTime start;
            DateTime total = DateTime.Now;
            Station stationFind;
            int i=0;
            foreach(string value in adresse)
            {
                start = DateTime.Now;
                stationFind = client.FindStationAsync(value, true, false).Result;
                Console.WriteLine("Time to find station in "+value+" : " + DateTime.Now.Subtract(start).ToString() + "s");
                if (stationFind == null)
                {
                    Console.WriteLine("STATION NULL");
                }
                i++;
            }
            Console.WriteLine("Number of request : " + i.ToString());
            Console.WriteLine("Total time : "+DateTime.Now.Subtract(total).ToString()+ "s");
            client.Close();
        }
    }
}
