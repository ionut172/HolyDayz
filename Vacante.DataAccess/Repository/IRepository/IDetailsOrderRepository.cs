using System;
using VacanteAPP.Models;
using VacanteAPP.Models.ViewModels;

namespace Vacante.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<VacanteAPP.Models.OrderHeader>
    {
        void Update(VacanteAPP.Models.OrderHeader obj);

    }
}

