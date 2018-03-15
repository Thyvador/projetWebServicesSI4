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
            while (command != "quit" || command != "q")
            {
                Console.WriteLine("velibs\n>");
                command = Console.ReadLine();

                switch (command)
                {
                    case "help":
                    case "h":
                        Help();
                        break;
                    case "ListCities":
                    case "listcities":
                        ListCities();
                        break;
                    case "ListStations":
                    case "liststations":
                        ListStations();
                        break;
                    case "StationDetails":
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

        private static void GetStationDetails()
        {
            Console.WriteLine("City name : ");
            string city = Console.ReadLine();
            Console.WriteLine("Station number: ");
            int number = Console.Read();
            var station = service.GetStation(city, number);

            Console.WriteLine("Station: " + station.Name);
            Console.WriteLine("Adress: " + station.Address);
            Console.WriteLine("Available Bikes: " + station.Available_Bikes);
            Console.WriteLine("Available Bike Stands: " + station.Available_Bike_Stands);
        }

        private static void ListStations()
        {
            Console.WriteLine("City name : ");
            CompositeStation[] stations = service.GetContract(Console.ReadLine());
            foreach(CompositeStation station in stations)
            {
                Console.WriteLine("Station: " + station.Name);
                Console.WriteLine("Adress: " + station.Address);
            }    
        }

        private static void ListCities()
        {
            CompositeContract[] contracts = service.GetContracts();
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
