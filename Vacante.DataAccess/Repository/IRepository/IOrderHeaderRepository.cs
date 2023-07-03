using System;
using VacanteAPP.Models;
using VacanteAPP.Models.ViewModels;

namespace Vacante.DataAccess.Repository.IRepository
{
    public interface IVacanteStandardRepository : IRepository<VacanteAPP.Models.VacanteStandard>
    {
        void Update(VacanteAPP.Models.VacanteStandard vacanteStandard);
        void Update(VacanteStandardVM obj);
    }
}

