using AirportApp.Helper;
using AirportApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportApp.Repository
{
    public interface IAirportDataRepository
    {
        AirportDetails GetAirportData(List<Airport> AirportListObj, IServiceHelperRepository _ServiceHelperRepository);

        AirportDetails GetAirportDetails(IServiceHelperRepository _ServiceHelperRepository);
    }
}
