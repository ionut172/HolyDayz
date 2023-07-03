using System;
using System.Linq.Expressions;
using Vacante.DataAccess.Data;
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
    }
}

