using System;
using VacanteAPP.Models;

namespace Vacante.DataAccess.Repository.IRepository
{
    public interface IOrderDetailsRepository : IRepository<Category>
    {
        void Update(Category category);

    }
}

