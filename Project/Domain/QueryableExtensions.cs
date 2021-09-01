using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    static class QueryableExtensions
    {
        public static IQueryable<T>Page<T>(this IQueryable<T>query,int page=1,int pageSize=10)
        {
            return query.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
