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

        public List<Place> GetAllByCityId(Guid cityId)
        {
            return db.Places.Where(p => p.City.Id == cityId).ToList();
        }

        public List<Place> GetAllByCityIdAndCategoryId(Guid cityId, List<Guid> categoriesId)
        {
            //List<Place> places = new List<Place>();
            //places = GetAllByCityId(cityId);
            //return places.Where(p=>(p.Categories.Where(j=>j.Id==categoty))!=null).ToList();
            //places.Where(p=>p.City=cityId)
        }
    }
}
