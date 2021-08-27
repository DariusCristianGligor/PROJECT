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
        public Guid CityId { set; get; }
        public City City { set; get; }
        public ICollection<Review> Reviews { set; get; }
        public ICollection<Category> Categories { set; get; }
      
  
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
