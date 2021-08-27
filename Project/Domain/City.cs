using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class City
    {
        public Guid Id { get; set; }
        public string Name { set; get; }

        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Place> Places { get; set; }

        
        public override string ToString()
        {
            return $"Name:{Name}";
        }
    }
}
