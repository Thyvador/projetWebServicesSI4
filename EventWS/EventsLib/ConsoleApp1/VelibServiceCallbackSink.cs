using ConsoleApp1.VelibsServiceReference;
using System;

namespace ConsoleApp1
{
    class VelibServiceCallbackSink : VelibsServiceReference.IVelibsServiceCallback
    {
        public void GetContractFinished()
        {
            Console.WriteLine("Get Contract Finished");
        }

        public void GetStationFinished()
        {
            Console.WriteLine("Get Station Finished");
        }

        public void GotContract(string city, CompositeStation[] result)
        {
            Console.WriteLine("City: " + city);
            foreach(var station in result)
            {
                Console.WriteLine("Name: "+ station.Name + ", Adress: " + station.Address + ", Number: " + station.Number);
            }
        }

        public void GotStation(string city, int station, CompositeStation result)
        {
            Console.WriteLine("City: " + city);
            Console.WriteLine("Station number: " + station);
            Console.WriteLine("Available bikes: " + result.Available_Bikes);
            Console.WriteLine("Available bikes stands: " + result.Available_Bike_Stands);
            Console.WriteLine("Bonus: " + result.Bonus);
            Console.WriteLine("Position: [Lng: " + result.Position.Lng + " ,Lat: " + result.Position.Lat + "]");

        }
    }
}