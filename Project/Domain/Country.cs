using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
     public class Country
    {
        public Guid Id { get; set; }
        public string Name { set; get; }
        public List<City> Cities { set; get; }
        public override string ToString()
        {
            return $"Name:{Name}";
        }
    }
}
