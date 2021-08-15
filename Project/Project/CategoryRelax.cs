using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class CategoryRelax :CategoryyDecorator
    {
        public CategoryRelax(CategoryComponent category) : base(category)
        { 
        }

        public override string addToDescription()
        {
            return $"{base.addToDescription()}+relax ";
        }
    }
}
