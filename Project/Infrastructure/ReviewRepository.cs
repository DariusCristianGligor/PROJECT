using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ReviewRepository : IReviewRepository
    {
        private Db db = new Db();

        private readonly ReviewNowContext _dbContext;

        public ReviewRepository(ReviewNowContext dbContext)
        {

            _dbContext = dbContext;
        }
        public void Add(Review review)
        {
            db.Reviews.Add(review);
            //_dbContext.Reviews.Add(review);
        }

        public void Delete(Guid idReview)
        {
            return db.Reviews.Where(p =>p.Place.Id == placeId).ToList();
            return db.Reviews.Where(p =>p.Place == place).ToList();
            //return _dbcontext.Reviews.Where(p =>p.Place == place).ToList();
        }

    }
}
