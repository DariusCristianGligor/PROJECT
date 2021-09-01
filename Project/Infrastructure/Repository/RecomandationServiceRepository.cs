using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RecomandationServiceRepository : IRecomandationService
    {
        protected ReviewNowContext _dbContext;
        public RecomandationServiceRepository(ReviewNowContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void RecalculateRating(Review review)
        {
            Place place = _dbContext.Places.Single(x => x.Id == review.PlaceId);
            place.AvgStars = (place.NumberOfReview * place.AvgStars + review.Stars) / (++place.NumberOfReview);
            place.Rating = (float)((place.AvgStars * 0.9) + (place.NumberOfReview * 0.1));
            _dbContext.SaveChanges();
        }
    }
}
