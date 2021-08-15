using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class CategoryDecoratorConcret : CategoryComponent
    {
        protected string _name;
        protected string _description;
        public CategoryDecoratorConcret(string name, string description)
        {

            _name = name;
            _description = description;
        }
        public override string addToDescription()
        {
            return $"{_name}::{_description}\n if you come here you can ";
        }

        public void setDescription(string description)
        {

            _description = description;
        
        }
        public string getDescription()
        {
            return _description;
        }

    }
}
