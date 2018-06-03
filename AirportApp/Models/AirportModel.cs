using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Script.Serialization;

namespace AirportApp.Helper
{
    public class Airport
    {
        public string iata { get; set; }
        public string lon { get; set; }
        public string iso { get; set; }
        public int status { get; set; }
        public string name { get; set; }
        public string continent { get; set; }
        public string type { get; set; }
        public string lat { get; set; }
        public string size { get; set; }
    }

}