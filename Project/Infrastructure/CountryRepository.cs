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
        private Db db = new Db();
        private readonly ReviewNowContext _dbContext;

        public CountryRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;
        }
        public List<Country> GetAll()
        {
           // return db.Countries;
          return _dbContext.Countries.ToList();
        }
        public void AddCountry(Country country)
        {
            _dbContext.Countries.Add(country);
        }
    }
}
