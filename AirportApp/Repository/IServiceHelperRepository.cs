using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportApp.Repository
{
    public interface IServiceHelperRepository
    {
        string GetjsonStream();

        Dictionary<string, string> GetCountryStream(HashSet<string> CountryList);
    }
}
