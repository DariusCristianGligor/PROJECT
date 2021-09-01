using Application;
using Domain;

using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ReviewRepository : IReviewRepository
    {
       

        private readonly ReviewNowContext _dbContext;

        public ReviewRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;
        }
        public void Add(Review review)
        {
            _dbContext.Reviews.Add(review);
            var recomandationService = new RecomandationServiceRepository(_dbContext);
            recomandationService.RecalculateRating(review);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid idReview)
        {
            //return db.Reviews.Where(p =>p.Place.Id == placeId).ToList();
            //return db.Reviews.Where(p =>p.Place == place).ToList();
            //return _dbcontext.Reviews.Where(p =>p.Place == place).ToList();
            //_dbContext.Reviews.Remove();
            _dbContext.Reviews.RemoveRange(_dbContext.Reviews.Where(x => x.Id == idReview).ToList());
          
        }

        
    }
}
