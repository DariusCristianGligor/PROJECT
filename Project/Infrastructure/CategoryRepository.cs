using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CategoryRepository : ICategoryRepository
    {
        private Db db = new Db();

        private readonly ReviewNowContext _dbContext;

        public CategoryRepository(ReviewNowContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Category> GetAll()
        {
            return db.Categories;
            //return _dbContext.Categories;
        }
        public void AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
        }
    }
}
