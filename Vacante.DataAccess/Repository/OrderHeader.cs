using System;
using System.Linq.Expressions;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Repository.IRepository;
using Vacante.DataAccess.Repository.Repository;
using VacanteAPP.Models;
using VacanteAPP.Models.ViewModels;

namespace Vacante.DataAccess.Repository
{
    public class ShoppingCart : Repository<VacanteAPP.Models.ShoppingCart>, IShoppingCartRepository
    {

        protected ApplicationDBContext _db;
        public ShoppingCart(ApplicationDBContext db) : base(db)
        {
            this._db = db;
        }
        public void Update(ShoppingCart obj)
        {
            _db.Update(obj);
        }

        public void Update(VacanteAPP.Models.ShoppingCart shoppingCart)
        {
            _db.shoppingCarts.Update(shoppingCart);
        }
    }
}

