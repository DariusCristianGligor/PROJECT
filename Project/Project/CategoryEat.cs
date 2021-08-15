using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class CategoryEat : CategoryyDecorator
    {
        public CategoryEat(CategoryComponent category) : base(category)
        {
        }

        public override string addToDescription()
        {
            return $"{base.addToDescription()} + to eat something healthy and good";
        }
    }
}
