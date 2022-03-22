

using System.Net;
using System.Text.Json;
using System.Web;

public class Position
{
    public double lat { get; set; }
    public double lng { get; set; }
}

public class Station
{
    public int number { get; set; }
    public string contract_name { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public Position position { get; set; }
    public bool banking { get; set; }
    public bool bonus { get; set; }
    public int bike_stands { get; set; }
    public int available_bike_stands { get; set; }
    public int available_bikes { get; set; }
    public string status { get; set; }
    public object last_update { get; set; }
}

namespace WebProxyService
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static string data = "";
        private static int request_number = 0;
        private static DateTime date;

        static async Task Main(string[] args)
        {
            Console.WriteLine("===== WebProxyService =====");
            Console.WriteLine("> Server start...");

            if (!HttpListener.IsSupported)
            {
                Console.WriteLine("WARNING SERVER DON'T START !");
                Console.WriteLine("A more recent Windows version is required to use the HttpListener class.");
                Console.WriteLine("> Server stop...");
                return;
            }

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();

            Console.CancelKeyPress += delegate {
                // call methods to close socket and exit
                listener.Stop();
                listener.Close();
                Environment.Exit(0);
            };

            await refresh_data();

            if (data != "")
            {
                List<Station> allData = JsonSerializer.Deserialize<List<Station>>(data);
                string msg = "";
                String station_id = "";
                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    HttpListenerRequest request = context.Request;

                    if (request.Url.Segments.Length >= 1)
                    {
                        if (request.Url.Segments[1].Equals("all_stations"))
                        {
                            var answer = JsonSerializer.Serialize(allData);
                            msg = answer.ToString();
                            if (DateTime.Now > date)
                            {
                                await refresh_data();
                                date = DateTime.Now.AddSeconds(30);
                            }
                        }
                        else if (request.Url.Segments[1].Equals("get_station"))
                        {
                            station_id = HttpUtility.ParseQueryString(request.Url.Query).Get("station_id");
                            if(station_id != null)
                            {
                                msg = "one station " + station_id;
                            }
                            else
                            {
                                msg = "null_id given";
                            }
                        }
                        else
                        {
                            msg = "Default Answer";
                        }
                    }
                    else
                    {
                        msg = "Default Answer";
                    }

                    HttpListenerResponse response = context.Response;
                    string responseString = msg;
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                    response.ContentLength64 = buffer.Length;
                    System.IO.Stream output = response.OutputStream;
                    output.Write(buffer, 0, buffer.Length);
                    Console.WriteLine("Request receive...");
                    output.Close();
                }
            }

            else
            {
                Console.WriteLine("No data found !");
                Console.WriteLine("> Server stop...");
            }
        }

        static async Task refresh_data()
        {
            request_number++;
            client.DefaultRequestHeaders.Accept.Clear();
            var stringTask = client.GetStringAsync("https://api.jcdecaux.com/vls/v1/stations?apiKey=f6b6a6117dc8092d548db6238ff42198ec4f2449");
            data = await stringTask;
            Console.WriteLine("GET ALL STATION...");
            Console.WriteLine("Data up to date at " + DateTime.Now + " | Request counter : "+ request_number);
            date = DateTime.Now.AddSeconds(30);
        }

    }
}

internal class InternalCallAPI
{
    public static Station get_one_station(int latitude, int longitude, List<Station> allData)
    {
        Station found = allData[0];
        for (int i = 1; i < allData.Count; i++)
        {
            Station station = allData[i];
            if(Math.Abs(Math.Abs(station.position.lat)-Math.Abs(latitude)) 
                < Math.Abs(Math.Abs(found.position.lat) - Math.Abs(latitude))
                && Math.Abs(Math.Abs(station.position.lng) - Math.Abs(longitude))
                < Math.Abs(Math.Abs(found.position.lng) - Math.Abs(longitude)))
            {
                found = station;
            }

        }
        return found;
    }
}