using System;
using System.Linq.Expressions;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Repository.IRepository;
using Vacante.DataAccess.Repository.Repository;
using VacanteAPP.Models;
using VacanteAPP.Models.ViewModels;

namespace Vacante.DataAccess.Repository
{
    public class OrderDetails : Repository<VacanteAPP.Models.OrderDetails>, IDetailsOrderRepository
    {

        protected ApplicationDBContext _db;
        public OrderDetails(ApplicationDBContext db) : base(db)
        {
            this._db = db;
        }
        public void Update(OrderDetails obj)
        {
            _db.Update(obj);
        }

        public void Update(VacanteAPP.Models.OrderDetails shoppingCart)
        {
            _db.orderDetails.Update(shoppingCart);
        }

        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            var orderFromDb = _db.orderDetails.FirstOrDefault(u => u.ID == id);
            if (orderFromDb != null)
            {
                orderFromDb.OrderHeader.OrderStatus = orderStatus;
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderFromDb.OrderHeader.PaymentStatus = paymentStatus;
                    orderFromDb.OrderHeader.OrderStatus = orderStatus;
                }
            }
        }

        public void UpdateStripePaymentId(int id, string sessionId, string? paymentId = null)
        {
            var orderFromDb = _db.orderDetails.FirstOrDefault(u => u.ID == id);
            if (orderFromDb != null)
            {
                if (sessionId != null)
                {
                    orderFromDb.OrderHeader.SessionId = sessionId;
                }
                if (paymentId != null)
                {
                    orderFromDb.OrderHeader.PaymentId = paymentId;
                    orderFromDb.OrderHeader.PaymentDate = DateTime.Now;
                }
            }
        }

    }
}

