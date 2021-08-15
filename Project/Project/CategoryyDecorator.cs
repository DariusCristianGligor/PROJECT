using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    abstract class CategoryyDecorator:CategoryComponent
    {
        protected CategoryComponent _category;
        public CategoryyDecorator(CategoryComponent category)
        {
            _category = category;
        }

        public void setCategoryComponent(CategoryComponent category)
        {
            _category = category;
        }
        public CategoryComponent getCategoryComponent()
        {
            return _category;
        }

        public override string addToDescription()
        {
            return ($"{this._category.addToDescription()}");
        }
    }
}
