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
      
        }
    }
}
