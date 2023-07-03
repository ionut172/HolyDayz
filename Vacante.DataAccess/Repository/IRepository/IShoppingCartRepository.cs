using System;
using VacanteAPP.Models;
using VacanteAPP.Models.ViewModels;

namespace Vacante.DataAccess.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<VacanteAPP.Models.ShoppingCart>
    {

        void Update(ShoppingCart obj);
        void Update(VacanteAPP.Models.ShoppingCart shoppingCart);
    }
}

