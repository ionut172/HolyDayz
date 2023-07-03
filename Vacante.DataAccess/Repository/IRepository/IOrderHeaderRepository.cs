using System;
using VacanteAPP.Models;
using VacanteAPP.Models.ViewModels;

namespace Vacante.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<VacanteAPP.Models.OrderHeader>
    {
        void Update(VacanteAPP.Models.OrderHeader obj);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
        void UpdateStripePaymentId(int id, string sessionId, string? paymentId = null);
    }
}

