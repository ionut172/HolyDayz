using System;
namespace Vacante.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IOrderDetailsRepository Category { get; }
        IVacanteStandardRepository VacanteStandard { get; }
        ILastMinuteRepository lastMinute { get; }
        ICountriesRepository countries { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IApplicationUserRepository applicationUser { get; }
        IDetailsOrderRepository detailsOrderRepository { get; }
        IOrderHeaderRepository orderHeaderRepository { get; }
        void Save();
    }
}

