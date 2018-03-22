using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelibsConsoleClient.ServiceReference1;

namespace VelibsConsoleClient
{
    class Program
    {
        private static ServiceReference1.VelibsServiceClient service;

        static void Main(string[] args)
        {
            service = new ServiceReference1.VelibsServiceClient();
            string command = "";
            Console.WriteLine("velibs");
            while (command != "quit" || command != "q")
            {
                Console.WriteLine("> ");
                command = Console.ReadLine();

                switch (command.ToLower())
                {
                    case "help":
                    case "h":
                        Help();
                        break;
                    case "listcities":
                        ListCities();
                        break;
                    case "liststations":
                        ListStations();
                        break;
                    case "stationdetails":
                        GetStationDetails();
                        break;
                    case "quit":
                    case "q":
                    default:
                        break;
                    
                }
                    
            }

        }

        private async static void GetStationDetails()
        {
            Console.WriteLine("City name : ");
            string city = Console.ReadLine();
            Console.WriteLine("Station number: ");
            int number = Console.Read();
            var station = await service.GetStationAsync(city, number);

            Console.WriteLine("Station: " + station.Name);
            Console.WriteLine("Adress: " + station.Address);
            Console.WriteLine("Available Bikes: " + station.Available_Bikes);
            Console.WriteLine("Available Bike Stands: " + station.Available_Bike_Stands);
        }

        private async static void ListStations()
        {
            Console.WriteLine("City name : ");
            CompositeStation[] stations = await service.GetContractAsync(Console.ReadLine());
            foreach(CompositeStation station in stations)
            {
                Console.WriteLine("Station: " + station.Name);
                Console.WriteLine("Adress: " + station.Address);
                Console.WriteLine("Station Number: " + station.Number);
            }    
        }

        private async static void ListCities()
        {
            CompositeContract[] contracts = await service.GetContractsAsync();
            foreach (CompositeContract contract in contracts)
            {
                Console.WriteLine(contract.Name);
            }
        }

        private static void Help()
        {
            Console.WriteLine("List of the cmmands:");
            Console.WriteLine("$ ListCities : List the cities available on JCDecaux system");
            Console.WriteLine("$ ListStations : List the stations in the city");
            Console.WriteLine("$ StationDetails : Give the details about the selected station");
            Console.WriteLine("$ quit (q) : Close the client");
        }
    }
}
