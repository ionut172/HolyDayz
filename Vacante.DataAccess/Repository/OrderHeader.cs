using System;
using System.Linq.Expressions;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Migrations;
using Vacante.DataAccess.Repository.IRepository;
using Vacante.DataAccess.Repository.Repository;
using VacanteAPP.Models;
using VacanteAPP.Models.ViewModels;

namespace Vacante.DataAccess.Repository
{
    public class OrderHeader : Repository<VacanteAPP.Models.OrderHeader>, IOrderHeaderRepository
    {

        protected ApplicationDBContext _db;
        public OrderHeader(ApplicationDBContext db) : base(db)
        {
            this._db = db;
        }
        public void Update(OrderHeader obj)
        {
            _db.Update(obj);
        }

        public void Update(VacanteAPP.Models.OrderHeader shoppingCart)
        {
            _db.orderHeaders.Update(shoppingCart);
        }
        public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
        {
            //var orderFromDb = _db.orderDetails.FirstOrDefault(u => u.ID == id);
            //if (orderFromDb != null)
            //{
            //    orderFromDb = _db.O;
            //    if (!string.IsNullOrEmpty(paymentStatus))
            //    {
            //        orderFromDb.OrderHeader.PaymentStatus = paymentStatus;
            //    }
            //}

            var orderFromDb = _db.orderHeaders.FirstOrDefault(u => u.ID == id);
            if (orderFromDb != null)
            {
                if (!string.IsNullOrEmpty(paymentStatus))
                {
                    orderFromDb.OrderStatus = orderStatus;
                    orderFromDb.PaymentStatus = paymentStatus;
                }

            }
        }
        public void UpdateStripePaymentId(int id, string sessionId, string? paymentId = null)
        {
            var orderFromDb = _db.orderHeaders.FirstOrDefault(u => u.ID == id);
            if (orderFromDb != null)
            {
                if (sessionId != null)
                {
                    orderFromDb.SessionId = sessionId;
                }
                if (paymentId != null)
                {
                    orderFromDb.PaymentId = paymentId;
                    orderFromDb.PaymentDate = DateTime.Now;
                }
            }
        }


    }
}

