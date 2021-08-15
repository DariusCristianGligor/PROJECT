using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Fecade
    {
        protected User user;
        protected Review review;
        public Fecade(User user, Review review)
        {
            this.user = user;
            this.review = review;
        }
        public string checkAndADD()
        { bool userCheck = user.checkReview(review);
            bool reviewCheck = review.checkUser(user);
            if (userCheck == false)
            {
                user.addReview(review);
            }
            if (reviewCheck == false)
            {
                review.User = user;
            }
            return $"We checked all the posibilities and now the user is associed with review";
        }
    }
}
