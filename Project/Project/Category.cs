using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Category
    {
        public Guid IdCategory { get; }
        public string Name { set; get; }
        public string Description { set; get; }

        public Category(string name, string description)
        {
            IdCategory = new Guid();
            Name = name;
            Description = description;
        }
        public override string ToString()
        {
            return $"Name:{Name}::{Description}";
        }
    }
}
