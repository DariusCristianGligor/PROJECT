using Domain;
using System;
using System.Collections.Generic;

namespace Application
{

    public interface ICountryRepository
    {
        ICollection<Country> GetAll();
    }
}
