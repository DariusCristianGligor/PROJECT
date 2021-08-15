using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
   interface IUUser
    {
        bool checkReview(Review rev);
        void addReview(Review review);

    }
}
