using Application;
using Domain;
using infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CityRepository : ICityRepository
    {
        private Db db = new Db();
        private readonly ReviewNowContext _dbContext;

        public CityRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;
        }
        public List<City> GetCitiesByCountryId(Guid countryId)
        {
            //return db.Cities.Where(p=>p.Country. == countryId).ToList();
            //return db.Cities.Where(p=>p.Country.Id == countryId).ToList();
            //return db.Cities.Where(p=>p.Country.Id == countryId).ToList();
            //return _dbContext.Cities.Where(p=>p.Country.Id == cityId).ToList();
            return _dbContext.Cities.Where(x => x.CountryId == countryId).ToList();
        }
        public void AddCity(City city)
        {
            _dbContext.Cities.Add(city);
        }
    }
}
