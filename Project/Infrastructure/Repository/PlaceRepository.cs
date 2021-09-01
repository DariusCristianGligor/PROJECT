using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
     public class PlaceRepository:IPlaceRepository
    {
        private readonly ReviewNowContext _dbContext;


        public PlaceRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;
        }
        public void AddCountry(Country country)
        {
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
        }
        public ICollection<Place> GetAllByCityId(Guid city)
        {
            return _dbContext.Places.Where(x => x.CityId == city).ToList();
        }
        public void AddPlace(Place place)
        {
            _dbContext.Places.Add(place);
            _dbContext.SaveChanges();
        }

        public ICollection<Place> GetAllByCityIdAndCategoryId(Guid cityId, ICollection<Guid> categoriesId)
        {
            ICollection<Place> places = GetAllByCityId(cityId);
            return places.Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id))).ToList();
        }
        public ICollection<Place> GetAllByCategoryId( ICollection<Guid> categoriesId)
        {
            return _dbContext.Places.Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id))).ToList();
        }
        public ICollection<Place> GetAllByCategoryIdAndCountryId(ICollection<Guid> categoriesId,Guid CountryId)
        {
            ICollection<Place> places = new List<Place>();
            places = _dbContext.Places.Where(x => x.City.CountryId == CountryId).ToList();
            return places.Where(x => x.Categories.Any(x => categoriesId.Contains(x.Id))).ToList();
        }
        public ICollection<Place> GetAllOrderedByRating()
        {
            return _dbContext.Places.OrderByDescending(x=>x.Rating).ToList();
        }
    }
}
