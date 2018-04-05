using System;

namespace VelibsClientsWS
{
    class Program
    {
        static void Main(string[] args)
        {
            VelibServiceCallbackSink objsink = new VelibServiceCallbackSink();
            InstanceContext iCntxt = new InstanceContext(objsink);

            VelibServiceReference.VelibServiceClient objClient = new VelibServiceReference.VelibServiceClient(iCntxt);
            objClient.SubscribeCalculatedEvent();
            objClient.SubscribeCalculationFinishedEvent();

           

            Console.WriteLine("Press any key to close ...");
            Console.ReadKey();
        }
    }
}
