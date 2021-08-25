using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    class CityRepository : ICityRepository
    {
        private Db db = new Db();
        public List<City> GetCitiesByCountryId(Guid countryId)
        {
            return db.Cities.Where(p=>p.Country.Id == countryId).ToList();
        }
    }
}
