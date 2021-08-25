using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Place : IEquatable<Place>
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public float SumStarts{ set; get; }
        public float Avg {set; get;}
        public int NumberOfReview { set; get; }
        public City City { set; get;}
        public List<Review> Reviews { set; get;}
        public List<Category> Categories { set; get;}
        public Place(string name,string address,City city)
        {
        Id = new Guid();
        Name = name;
        Address = address;
        City = city;
        }
        public Place(string name, string address, City city, List<Category> categories):this(name,address,city)
        {
            Categories = categories;
        }

        public void AddCategory(Category category)
        {
            Categories.Add(category);
        }
        public void AddReview(Review review)
        {
            Reviews.Add(review);
            //Sum = Sum + review.Note;
            //NumberofReview += 1;
            Avg = (Avg * (NumberOfReview) + review.Stars) / (NumberOfReview + 1);
            NumberOfReview += 1;
        }
        public override string ToString()
        {
            return $"Name:{Name}::Address:{Address}";
        }
        public bool Equals(Place other)
        {
            if (other is null)
                return false;

            if ((this.Address == other.Address) && (this.Name == other.Name))
                return true;
            else return false;

        }
        public override bool Equals(object obj) => Equals(obj as Place);
        public override int GetHashCode() => (Name, Id).GetHashCode();
    }
}
