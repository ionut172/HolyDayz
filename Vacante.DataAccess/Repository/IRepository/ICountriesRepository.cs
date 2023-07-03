using System;
using VacanteAPP.Models;

namespace Vacante.DataAccess.Repository.IRepository
{
    public interface ICountriesRepository : IRepository<VacanteAPP.Models.Countries>
    {
        void Update(VacanteAPP.Models.Countries countries);
    }
}

