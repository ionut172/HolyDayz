using System;
using VacanteAPP.Models;
using VacanteAPP.Models.ViewModels;

namespace Vacante.DataAccess.Repository.IRepository
{
    public interface IDetailsOrderRepository : IRepository<VacanteAPP.Models.OrderDetails>
    {
        void Update(VacanteAPP.Models.OrderDetails obj);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
        void UpdateStripePaymentId(int id, string sessionId, string? paymentId = null);
    }
}

