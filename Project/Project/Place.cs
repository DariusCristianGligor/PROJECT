using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Place : IEquatable<Place>
    {

        public bool Equals(Place other)
        {
            if (other is null)
                return false;

            if ((this.Address == other.Address) && (this.Name == other.Name))
                return true;
            else return false;

        }
        public override bool Equals(object obj) => Equals(obj as Place);
        public override int GetHashCode() => (Name, IdPlace).GetHashCode();

        public string Name { set; get; }
        public string Address { set; get; }
        public Guid IdPlace { set; get; }

        public Guid City { set; get; }
        public List<Review> reviews { set; get; }
        public Place(string name,string address,Guid city)
        {
        IdPlace = new Guid();
        Name = name;
        Address = address;
        City = city;
        } 
        public void addReview(Review review)
        {
            reviews.Add(review);
        }
        public override string ToString()
        {
            return $"Name:{Name}::Address:{Address}";
        }
    }
}
