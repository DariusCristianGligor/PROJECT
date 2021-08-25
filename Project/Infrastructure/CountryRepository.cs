using Application;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    class CountryRepository : ICountryRepository
    {
        private Db db = new Db();
        public List<Country> GetAll()
        {
            return db.Countries;
        }
    }
}
