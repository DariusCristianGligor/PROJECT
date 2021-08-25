using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    class CategoryRepository : ICategoryRepository
    {
        private Db db = new Db();
        public List<Category> GetAll()
        {
            return db.Categories;
        }
    }
}
