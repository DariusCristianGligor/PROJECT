using Domain;
using System;
using System.Collections.Generic;

namespace Application
{

    public interface ICountryRepository
    {
        List<Country> GetAll();
    }
}
