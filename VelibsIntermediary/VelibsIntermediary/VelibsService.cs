﻿using Newtonsoft.Json;
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
            return DataCache.getInstance().GetContract(city);
        }

        public List<CompositeContract> GetContracts()
        {
            return DataCache.getInstance().GetContracts();
        }

        public CompositeStation GetStation(string city, int station)
        {
            return DataCache.getInstance().GetStation(city, station);
        }
    }


}
