using AirportApp.Models;
using AirportApp.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Caching;
using System.Threading.Tasks;
using System.Web;

namespace AirportApp.Helper
{
    public class ServiceHelper : IServiceHelperRepository
    {
        /// <summary>
        /// Calls the Aiport Details API and Returns the List of Airports
        /// </summary>
        /// <returns></returns>
        public string GetjsonStream()
        {
            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(ConfigurationManager.AppSettings[Constants.Constants.FeedAirportData]);
            StreamReader reader = new StreamReader(stream);
            String request = reader.ReadToEnd();
            return request;
        }

        /// <summary>
        /// Calls the Countries API and Returns the Country code and its corresponding Country Name
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetCountryStream(HashSet<string> CountryList)
        {
            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(ConfigurationManager.AppSettings[Constants.Constants.FeedCountryData]);
            StreamReader reader = new StreamReader(stream);
            Dictionary<string, string> CountryDetails = new Dictionary<string, string>();
            string ReadLine = reader.ReadLine();
            while (ReadLine != null && ReadLine.Length > 0)
            {
                var Country = ReadLine.Split(',');
                var temp = Country.Skip(1).Take(Country.Length - 1);
                foreach (var CountryCode in temp)
                {
                    if (CountryList.Contains(CountryCode))
                    {
                        if (!CountryDetails.ContainsKey(CountryCode))
                        {
                            CountryDetails.Add(CountryCode, Country[0]);
                        }
                    }
                }
                ReadLine = reader.ReadLine();
            }
            return CountryDetails;
        }     
    }
}