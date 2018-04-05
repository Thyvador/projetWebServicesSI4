using System.Collections.Generic;
using System.ServiceModel;

namespace EventsLib
{
    internal interface IVelibsServiceEvents
    {
        [OperationContract(IsOneWay = true)]
        void GetContract(string city, List<CompositeStation> result);

        [OperationContract(IsOneWay = true)]
        void GetContractFinished();

        [OperationContract(IsOneWay = true)]
        void GetStation(string city, int station, CompositeStation result);

        [OperationContract(IsOneWay = true)]
        void GetStationFinished();
    }
}