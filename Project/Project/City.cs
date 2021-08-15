using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class City
    {
        public Guid IdCity { get; }
        public string Name { set; get; }

        public Guid Country { set; get; }

        public City(string name)
        {
            IdCity = new Guid();
            Name = name;
        }
        public City(string name, Guid country) : this(name)
        {
            Country = country;
        }
        public override string ToString()
        {
            return $"Name:{Name}";
        }
    }
}
