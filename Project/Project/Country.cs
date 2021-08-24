using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Country
    {
        public string Name { set; get; }
        public Guid IdCountry { get; }
        public List<City> Cities { set; get; }
        public Country(string name)
        {
            IdCountry = new Guid();
            Name = name;
        }
        public void AddCity(City city)
        {
            Cities.Add(city);
        }
        public override string ToString()
        {
            return $"Name:{Name}";
        }
    }
}
