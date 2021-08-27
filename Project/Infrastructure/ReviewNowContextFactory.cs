using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ReviewNowContextFactory : IDesignTimeDbContextFactory<ReviewNowContext>
    {
        public ReviewNowContextFactory()
        {

        }
        public ReviewNowContext CreateDbContext(string[] args)
        {
            return new ReviewNowContext(@"Server=LAPTOP-R308IB89\SQLEXPRESS;Database=ReviewNowMigration;Trusted_Connection=True;");
        }
    }
}
