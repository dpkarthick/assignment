using AirportApp.Models;
using AirportApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirportApp.Helper
{
    public class AirportData: IAirportDataRepository
    {
        /// <summary>
        /// Get the list of Airport Data available in  European Countries
        /// </summary>
        /// <param name="AirportListObj"></param>
        /// <param name="_ServiceHelperRepository"></param>
        /// <returns></returns>
        public AirportDetails GetAirportData(List<Airport> AirportListObj, IServiceHelperRepository _ServiceHelperRepository)
        {
            var EuropeanCities = AirportListObj.Where(x => x.continent.ToLower().Equals(Constants.Constants.EU) && x.continent.Length > 0 && x.status != 0).ToList();
            HashSet<string> countrySet = new HashSet<string>(EuropeanCities.Select(x => x.iso).ToList());
            AirportDetails AirportDetailsObj = new AirportDetails();
            AirportDetailsObj.AirportDetailsList = EuropeanCities;
            AirportDetailsObj.CountryList = _ServiceHelperRepository.GetCountryStream(countrySet);
            return AirportDetailsObj;
        }

        /// <summary>
        /// Returns Airport Detaisl Objecdt which contains both List of Airports and Countries
        /// </summary>
        /// <returns></returns>
        public AirportDetails GetAirportDetails(IServiceHelperRepository _ServiceHelperRepository)
        {
            List<Airport> AirportListObj = Helpers.JsonData(_ServiceHelperRepository);
            AirportDetails AirportDetailsObj = new AirportDetails();
            AirportDetailsObj = GetAirportData(AirportListObj, _ServiceHelperRepository);
            return AirportDetailsObj;
        }
      
    }
}