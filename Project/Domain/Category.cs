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
        public string Name { set; get; }
        public string Description { set; get; }
       
        public override string ToString()
        {
            return $"Name:{Name}::{Description}";
        }
    }
}
