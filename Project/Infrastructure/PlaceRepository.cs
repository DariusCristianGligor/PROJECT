using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
   public  class PlaceRepository:IPlaceRepository
    {
        private Db db = new Db();

        public List<Place> GetAllByCityId(Guid city)
        {
            return db.Places.Where(p => p.City.IdCity == city).ToList();
        }

        public List<Place> GetAllByCityIdAndCategoryId(Guid city, Guid categoty)
        {
            List<Place> places = new List<Place>();
            places = GetAllByCityId(city);
            return places.Where(p=>(p.Categories.Where(j=>j.Id==categoty))!=null).ToList();
        }
    }
}
