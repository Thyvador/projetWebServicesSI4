using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace VelibsLib
{
    [ServiceContract(CallbackContract = typeof(IVelibsServiceEvents))]
    public interface IVelibsService
    {
        /// <summary>
        /// Return all the stations available in the city.
        /// </summary>
        /// <param name="city"> The city</param>
        /// <returns></returns>
        [OperationContract]
        void GetContract(string city);

        /// <summary>
        /// Return the details of a station.
        /// </summary>
        /// <param name="station"></param>
        /// <returns></returns>
        [OperationContract]
        void GetStation(string city, int station);

        [OperationContract]
        void SubscribeGetContractEvent();

        [OperationContract]
        void SubscribeGetContractFinishedEvent();

        [OperationContract]
        void SubscribeGetStationEvent();

        [OperationContract]
        void SubscribeGetStationFinishedEvent();
    }

    [DataContract]
    public class CompositeStation
    {
        //{"number":156,"name":"00156 - METRO EMPALOT","address":"38 AV JEAN MOULIN FACE DEBOUCHE RUE DE CANNES"
        //,"position":{"lat":43.579737115748195,"lng":1.441783289134449},"banking":true
        //,"bonus":false,"status":"OPEN","contract_name":"Toulouse","bike_stands":18,"available_bike_stands":4
        //,"available_bikes":14,"last_update":1518614922000}
        int number;
        string name;
        string address;
        Position position;
        bool banking;
        bool bonus;
        string status;
        string contract_name;
        int bike_stands;
        int available_bike_stands;
        int available_bikes;
        long last_update;

        [DataMember]
        public long Last_Update
        {
            get { return last_update; }
            set { last_update = value; }
        }

        [DataMember]
        public int Available_Bikes
        {
            get { return available_bikes; }
            set { available_bikes = value; }
        }

        [DataMember]
        public int Available_Bike_Stands
        {
            get { return available_bike_stands; }
            set { available_bike_stands = value; }
        }

        [DataMember]
        public int Bike_Stands
        {
            get { return bike_stands; }
            set { bike_stands = value; }
        }

        [DataMember]
        public string Contract_Name
        {
            get { return contract_name; }
            set { contract_name = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        [DataMember]
        public Position Position
        {
            get { return position; }
            set { position = value; }
        }

        [DataMember]
        public bool Banking
        {
            get { return banking; }
            set { banking = value; }
        }

        [DataMember]
        public bool Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        public override string ToString()
        {
            return "{\"number\":"+ number+ ",\"name\":\"" + name + "\",\"address\":\"" + address + "\"" +
                    ",\"position\":{\"lat\":" + position.Lat + ",\"lng\":" + position.Lng + "},\"banking\":" + banking + 
                    ",\"bonus\":" + bonus + ",\"status\":\"" + status + "\",\"contract_name\":\"" + contract_name + "\",\"bike_stands\":" + bike_stands + "" +
                    ",\"available_bike_stands\":" + available_bike_stands + ",\"available_bikes\":" + available_bikes + ",\"last_update\":" + last_update + "}";
        }

    }

    [DataContract]
    public class Position
    {
        double lat;
        double lng;

        [DataMember]
        public double Lat
        {
            get { return lat; }
            set { lat = value; }
        }

        [DataMember]
        public double Lng
        {
            get { return lng; }
            set { lng = value; }
        }
    }

    [DataContract]
    public class CompositeContract
    {
        //"name":"Rouen","cities":["Rouen"],"commercial_name":"cy'clic","country_code":"FR"
        string name;
        List<string> cities;
        string commercial_name;
        string country_code;

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public List<string> Cities
        {
            get { return cities; }
            set { cities = value; }
        }

        [DataMember]
        public string Commercial_Name
        {
            get { return commercial_name; }
            set { commercial_name = value; }
        }
        [DataMember]
        public string Country_Code
        {
            get { return country_code; }
            set { country_code = value; }
        }
    }


}
