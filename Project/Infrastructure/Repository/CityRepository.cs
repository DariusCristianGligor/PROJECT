using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CityRepository : ICityRepository
    {
    
        private readonly ReviewNowContext _dbContext;

        public CityRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;
        }
        public ICollection<City> GetCitiesByCountryId(Guid countryId)
        {
            
            return _dbContext.Cities.Where(x => x.CountryId == countryId).ToList();
        }
        public ICollection<Place> GetPlaceOrderedByRating()
        {
            return _dbContext.Places.OrderByDescending(x=>x.Rating).ToList();
        }
        public void AddCity(City city)
        {
            _dbContext.Cities.Add(city);
            _dbContext.SaveChanges();

        }
    }
}
