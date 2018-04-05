using System.Collections.Generic;
using System.ServiceModel;

namespace VelibsLib
{
    internal interface IVelibsServiceEvents
    {
        [OperationContract(IsOneWay = true)]
        void GotContract(string city, List<CompositeStation> result);

        [OperationContract(IsOneWay = true)]
        void GetContractFinished();

        [OperationContract(IsOneWay = true)]
        void GotStation(string city, int station, CompositeStation result);

        [OperationContract(IsOneWay = true)]
        void GetStationFinished();
    }
}