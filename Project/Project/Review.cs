using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    enum Price
    {
        Cheap,
        Affordable,
        Expensive
    }
    class Review
    {
        public Guid IdReview { get; set; }
        public float Note { get; set; }
        public Price CostOfPlace{get;set;}
        public Category Category { get; set;}
        public Place Place { get; set; }
        public Review(float note, Price costofplace, Place place, Category category)
        {
            IdReview = new Guid();
            Note = note;
            Category = category;
            CostOfPlace = costofplace;
            Place = place;
        }
     
        public override string ToString()
        {
            return $"Name:{Place}::{Note}";
        }
        // a list of photo

    }
}
