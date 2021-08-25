﻿using System;
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

        public Country()
        {

        }
        public Country(string name)
        {
            Id = new Guid();
            Name = name;
        }
        public Country(string name, List<City> cities):this(name)
        {
            Cities = cities;
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
