using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    class ReviewRepository : IReviewRepository
    {
        private Db db = new Db();
        public void Add(Review review)
        {
            db.Reviews.Add(review);
        }

        public void Delete(Review review)
        {
            db.Reviews.Remove(review);
        }
        public List<Review> GetReviews(Place place)
        {
            return db.Reviews.Where(p =>p.Place == place).ToList();
        }
    }
}
