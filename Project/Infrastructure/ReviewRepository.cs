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

        public void Delete(Guid idReview)
        {
            var review = db.Reviews.Where( p => p.Id == idReview).FirstOrDefault();
            if (review != null)
            {
                db.Reviews.Remove(review);
            }
        }
        public List<Review> GetReviews(Guid placeId)
        {
            return db.Reviews.Where(p =>p.Place.Id == placeId).ToList();
        }

    }
}
