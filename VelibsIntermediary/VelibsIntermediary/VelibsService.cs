using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VelibsIntermediary
{
    //GET contracts
    //https://api.jcdecaux.com/vls/v1/contracts?apiKey=b941e47bb9524c3678fdc55de1788804bbcb004e

    //GET stations 
    //https://api.jcdecaux.com/vls/v1/stations?contract=<ville>&apiKey=b941e47bb9524c3678fdc55de1788804bbcb004e


    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class VelibsService : IVelibsService
    {
        public List<CompositeStation> GetContract(string city)
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

            return contractList;

        }

        public List<CompositeContract> GetContracts()
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
            
           

            return contractList;
        }

        public CompositeStation GetStation(string city, int station)
        {
            WebRequest request = WebRequest.Create(
               "https://api.jcdecaux.com/vls/v1/stations/" + station + "?contract=" + city +  "&apiKey=b941e47bb9524c3678fdc55de1788804bbcb004e");

            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            response.Close();

            return  JsonConvert.DeserializeObject<CompositeStation>(responseFromServer);
        }
    }


}
