using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace VelibsIntermediary
{
    class DataCache
    {
        private static DataCache instance = null;
        private DataTable stationTable = null;
        private DataTable contractTable = null;

        private const int CACHE_DURATION = 3;

        private DataCache()
        {
            contractTable = new DataTable();
            stationTable = new DataTable();
            contractTable.Columns.Add("Name", typeof(string));
            contractTable.Columns.Add("Contract", typeof(CompositeContract));
            contractTable.Columns.Add("TimeStamp", typeof(DateTime));
            stationTable.Columns.Add("CityName", typeof(string));
            stationTable.Columns.Add("StationId", typeof(int));
            stationTable.Columns.Add("Station", typeof(CompositeStation));
            stationTable.Columns.Add("TimeStamp", typeof(DateTime));
        }

        public static DataCache getInstance()
        {
            if (instance == null)
            {
                instance = new DataCache();
            }
            return instance;
        }

        public CompositeStation GetStation(string city, int station)
        {
            DataRow[] foundRows = stationTable.Select("CityName = '" + city + "' And StationId = '" + station + "'");
            if (foundRows.Length == 0)
            {
                return RequestStation(city, station);
            }
            DateTime currentTime = DateTime.Now;
            if ((currentTime - (DateTime)foundRows[0][3]).TotalMinutes >= CACHE_DURATION)
            {
                foundRows[0].Delete();
                return RequestStation(city, station);
            }
            return (CompositeStation)foundRows[0][2];
        }

        private CompositeStation RequestStation(string city, int station)
        {
            WebRequest request = WebRequest.Create(
               "https://api.jcdecaux.com/vls/v1/stations/" + station + "?contract=" + city + "&apiKey=b941e47bb9524c3678fdc55de1788804bbcb004e");

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            var compositeStation = JsonConvert.DeserializeObject<CompositeStation>(responseFromServer);

            DataRow row = stationTable.NewRow();
            row[0] = city;
            row[1] = station;
            row[2] = compositeStation;
            row[3] = DateTime.Now;

            return compositeStation;
        }

        public List<CompositeContract> GetContracts()
        {
            DateTime currentTime = DateTime.Now;
            List<CompositeContract> list = new List<CompositeContract>();
            if (contractTable.Select().Length == 0)
            {
                return RequestContracts();
            }
            foreach(DataRow row in contractTable.Rows)
            {
                if ((currentTime - (DateTime) row[2]).TotalMinutes  >= CACHE_DURATION)
                {
                    return RequestContracts();
                }
                list.Add((CompositeContract) row[1]);
            }
            return list;
        }

        private List<CompositeContract> RequestContracts()
        {
            WebRequest request = WebRequest.Create(
           "https://api.jcdecaux.com/vls/v1/contracts?apiKey=b941e47bb9524c3678fdc55de1788804bbcb004e");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            var contractList = JsonConvert.DeserializeObject<List<CompositeContract>>(responseFromServer);

            DateTime currentTime = DateTime.Now;

            foreach (CompositeContract contract in contractList)
            {
                DataRow row = contractTable.NewRow();

                row[0] = contract.Name;
                row[1] = contract;
                row[2] = currentTime;
            }

            return contractList;
        }

        public List<CompositeStation> GetContract(string city)
        {
            DataRow[] foundRows = contractTable.Select("Name = '" + city + "'");
            if (foundRows.Length == 0)
            {
                return RequestContract(city);
            }
            DateTime currentTime = DateTime.Now;
            if ((currentTime - (DateTime) foundRows[0][2]).TotalMinutes >= CACHE_DURATION)
            {
                foundRows[0].Delete();
                return RequestContract(city);
            }
            return (List<CompositeStation>) foundRows[0][1];
            

        }

        private List<CompositeStation> RequestContract(string city)
        {
            WebRequest request = WebRequest.Create(
             "https://api.jcdecaux.com/vls/v1/stations?contract=" + city + "&apiKey=b941e47bb9524c3678fdc55de1788804bbcb004e");

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            var contractList = JsonConvert.DeserializeObject<List<CompositeStation>>(responseFromServer);
            foreach (var station in contractList)
            {
                DataRow row = stationTable.NewRow();
                row[0] = city;
                row[1] = station.Number;
                row[2] = station;
                row[3] = DateTime.Now;
                stationTable.Rows.Add(row);
            }
            
            return contractList;
        }
    }
}
