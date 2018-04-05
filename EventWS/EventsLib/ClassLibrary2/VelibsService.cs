using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel;
using Newtonsoft.Json;

namespace VelibsLib
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class VelibsService : IVelibsService
    {

        static Action<string, List<CompositeStation>> m_EventC1 = delegate { };
        static Action m_EventC2 = delegate { };
        static Action<string, int, CompositeStation> m_EventS1 = delegate { };
        static Action m_EventS2 = delegate { };

        public void GetContract(string city)
        {
            WebRequest request = WebRequest.Create(
            "https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=b941e47bb9524c3678fdc55de1788804bbcb004e");

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            m_EventC1(city, JsonConvert.DeserializeObject<List<CompositeStation>>(responseFromServer));
            m_EventC2();
        }

        public void GetStation(string city, int station)
        {
            WebRequest request = WebRequest.Create(
               "https://api.jcdecaux.com/vls/v1/stations/" + station + "?contract=" + city + "&apiKey=b941e47bb9524c3678fdc55de1788804bbcb004e");

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            m_EventS1(city, station, JsonConvert.DeserializeObject<CompositeStation>(responseFromServer));
            m_EventS2();
        }

        public void SubscribeGetContractEvent()
        {
            IVelibsServiceEvents subscriber =
            OperationContext.Current.GetCallbackChannel<IVelibsServiceEvents>();
            m_EventC1 += subscriber.GotContract;
        }

        public void SubscribeGetStationEvent()
        {
            IVelibsServiceEvents subscriber =
            OperationContext.Current.GetCallbackChannel<IVelibsServiceEvents>();
            m_EventS1 += subscriber.GotStation;
        }

        public void SubscribeGetContractFinishedEvent()
        {
            IVelibsServiceEvents subscriber =
            OperationContext.Current.GetCallbackChannel<IVelibsServiceEvents>();
            m_EventC2 += subscriber.GetContractFinished;
        }

        public void SubscribeGetStationFinishedEvent()
        {
            IVelibsServiceEvents subscriber =
            OperationContext.Current.GetCallbackChannel<IVelibsServiceEvents>();
            m_EventS2 += subscriber.GetStationFinished;
        }

    }
}
