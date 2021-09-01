using Application;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CountryRepository : ICountryRepository
    {
        
        private readonly ReviewNowContext _dbContext;

        public CountryRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;
        }
        public ICollection<Country> GetAll()
        {
           
          return _dbContext.Countries.ToList();
        }
        public void AddCountry(Country country)
        {
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
        }

        public List<Country> GetAllCountriesWithCities()
        {
            List<Country> countries=_dbContext.Countries
                .Include(c => c.Cities)
                .ThenInclude(ci => ci.Country)
                .ToList();
            return countries;
            //eager loading
        }
    }
}
