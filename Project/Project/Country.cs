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
        public Guid idCountry { get; }
        public List<Guid> CityList { set; get; }
        public Country(string name)
        {
            idCountry = new Guid();
            Name = name;
        }
        public void addCity(Guid city)
        {
            CityList.Add(city);
        }
        public override string ToString()
        {
            return $"Name:{Name}";
        }
    }
}
