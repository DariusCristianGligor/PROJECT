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

         private readonly ReviewNowContext _dbContext;

        public CategoryRepository(ReviewNowContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ICollection<Category> GetAll() => _dbContext.Categories.ToList();
        public void AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();
  
        }

    }
}
