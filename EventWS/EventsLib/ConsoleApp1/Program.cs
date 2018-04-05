using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            VelibServiceCallbackSink objsink = new VelibServiceCallbackSink();
            InstanceContext iCntxt = new InstanceContext(objsink);
            VelibsServiceReference.VelibsServiceClient objClient = new VelibsServiceReference.VelibsServiceClient(iCntxt);
            VelibsServiceReference.VelibsServiceClient objClient1 = new VelibsServiceReference.VelibsServiceClient(iCntxt);
            objClient.SubscribeGetContractEvent();
            objClient.SubscribeGetContractFinishedEvent();

            objClient1.SubscribeGetStationEvent();
            objClient1.SubscribeGetStationFinishedEvent();

            Console.WriteLine("City: ");
            string city = Console.ReadLine();
            objClient.GetContract(city);

            Console.WriteLine("Station number: ");
            objClient1.GetStation(city, Int32.Parse(Console.ReadLine()));

            Console.WriteLine("Press any key to close ...");
            Console.ReadKey();
        }
    }
}
