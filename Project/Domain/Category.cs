using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
       
        public List<Place> Places { get; set; }
        public override string ToString()
        {
            return $"Name:{Name}::{Description}";
        }
    }
}
