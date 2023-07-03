using System;
using VacanteAPP.Models;

namespace Vacante.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);

    }
}

