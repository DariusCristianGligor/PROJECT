using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum Price
    {
        Cheap,
        Affordable,
        Expensive
    }
    public class Review: IEquatable<Review>
    {
        public Guid Id { get; set; }
        public int Stars { get; set; }
        public Price CostOfPlace{get;set;}
        public Guid IdPlAce { get; set; }
        public Place Place { get; set; }
        public Review()
        {
             
        }
        public Review(int stars, Price costofplace, Place place)
        {
            Id = new Guid();
            Stars = stars;  
            CostOfPlace = costofplace;
            Place = place;
        }
     
        public override string ToString()
        {
            return $"Name:{Place}::{Stars}";
        }

        public bool Equals(Review other)
        {
            if (other is null)
                return false;
            return (this.Id == other.Id);
        }
        // a list of photo
     
        public override bool Equals(object obj) => Equals(obj as Review);
        public override int GetHashCode() => (Id).GetHashCode();

    }
}
