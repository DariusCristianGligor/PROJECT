﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IReviewRepository
    {
        void Add(Review place);
        void Delete(Review review);
    }
}
