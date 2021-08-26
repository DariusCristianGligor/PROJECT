using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IPlaceRepository
    {
        List<Place> GetAllByCityId(Guid city);
        List<Place> GetAllByCityIdAndCategoryId(Guid cityId, List<Guid> categoriesId);
    }
}
