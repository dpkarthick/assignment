using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AirportApp.Helper;
using AirportApp.Models;
using AirportApp.Repository;
using System.Runtime.Caching;
using System.Threading.Tasks;
using AirportApp.Filters;

namespace AirportApp.Controllers
{
    [ExceptionHandler]
    public class AirportController : Controller
    {
        IAirportDataRepository _AirportDataRepository;

        IGeoLocationRepository _GeoLocationRepository;

        IServiceHelperRepository _ServiceHelperRepository;

        ICacheRepository _CacheRepository;
        public AirportController(IAirportDataRepository AirportDataRepository, IGeoLocationRepository GeoLocationRepository, IServiceHelperRepository ServiceHelperRepository, ICacheRepository CacheRepository)
        {
            _AirportDataRepository = AirportDataRepository;
            _GeoLocationRepository = GeoLocationRepository;
            _ServiceHelperRepository = ServiceHelperRepository;
            _CacheRepository = CacheRepository;
        }
        /// <summary>
        /// Displays the list of airports available in European Continent
        /// </summary>
        /// <returns></returns>
        [ExceptionHandler]
        public ActionResult AirportList()
        {                          
                AirportDetails AirportDetailsObj = new AirportDetails();
                AirportDetailsObj = _AirportDataRepository.GetAirportDetails(_ServiceHelperRepository);
                _CacheRepository.Set<AirportDetails>(Constants.Constants.Airport,AirportDetailsObj);             
                return View(AirportDetailsObj);           
        }

        /// <summary>
        /// CalculateDistance between Source and Destination
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Destination"></param>
        /// <returns></returns>
        
        [ExceptionHandler]
        public ActionResult CalculateDistance(string Source, string Destination)
        {
                var AirportData = _CacheRepository.Get<AirportDetails>(Constants.Constants.Airport);
                if (AirportData == null)
                {
                    AirportDetails AirportDetailsObj = new AirportDetails();
                    AirportDetailsObj = _AirportDataRepository.GetAirportDetails(_ServiceHelperRepository);
                    AirportData = AirportDetailsObj;
                    _CacheRepository.Set<AirportDetails>(Constants.Constants.Airport, AirportDetailsObj);
                }

                var Distance = _GeoLocationRepository.GetDistance(AirportData, Source, Destination);
                return Json(new { DistanceBetween = Math.Round(Distance, 2) });          
        }

        /// <summary>
        /// Displays the Airports based on country selection
        /// </summary>
        /// <returns></returns>
        
        [ExceptionHandler]
        public ActionResult AirportListBasedOnCountrySelection(string ISO)
        {           
                var AirportData = _CacheRepository.Get<AirportDetails>(Constants.Constants.Airport);
                if (AirportData == null)
                {
                    AirportDetails AirportDetailsObject = new AirportDetails();
                    AirportDetailsObject = _AirportDataRepository.GetAirportDetails(_ServiceHelperRepository);
                    AirportData = AirportDetailsObject;
                    _CacheRepository.Set<AirportDetails>(Constants.Constants.Airport, AirportDetailsObject);
                }
                var AirportsInCountries = AirportData.AirportDetailsList.Where(x => x.name != null && x.iso.ToLower().Equals(ISO.ToLower())).ToList();
                AirportDetails AirportDetailsObj = new AirportDetails();
                AirportDetailsObj.AirportDetailsList = AirportsInCountries;
                return PartialView(AirportDetailsObj);          
        }
      
    }
}