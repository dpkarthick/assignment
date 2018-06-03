using AirportApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportApp.Repository
{
    public interface IGeoLocationRepository
    {
        double GetDistance(AirportDetails AirportData, string Source, string Destination);
    }
}
