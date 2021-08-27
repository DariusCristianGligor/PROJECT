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
        ICollection<Place> GetAllByCityId(Guid city);
        ICollection<Place> GetAllByCityIdAndCategoryId(Guid cityId, ICollection<Guid> categoriesId);
    }
}
