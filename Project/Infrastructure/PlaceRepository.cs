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
        private Db db = new Db();
        private readonly ReviewNowContext _dbContext;

        public PlaceRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;
        }
        public List<Place> GetAllByCityId(Guid city)
        {
            return db.Places.Where(p => p.City.Id == city).ToList();
            //return _dbContext.Places.Where(p => p.City.Id == city).ToList();
        }

        public List<Place> GetAllByCityIdAndCategoryId(Guid city, Guid categoty)
        {
            List<Place> places = new List<Place>();
            places = GetAllByCityId(city);
            return places.Where(p=>(p.Categories.Where(j=>j.Id==categoty))!=null).ToList();
        }
    }
}
