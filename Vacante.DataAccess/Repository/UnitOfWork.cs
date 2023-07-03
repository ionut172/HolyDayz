using System;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Repository.IRepository;
using VacanteAPP.Models;

namespace Vacante.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _db;
        public IOrderDetailsRepository Category { get; private set; }
        public IVacanteStandardRepository VacanteStandard { get; private set; }
        public ILastMinuteRepository lastMinute { get; private set; }
        public ICountriesRepository countries { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IOrderHeaderRepository orderHeaderRepository { get; private set; }
        public IDetailsOrderRepository detailsOrderRepository { get; private set; }
        public IApplicationUserRepository applicationUser { get; private set; }

        public UnitOfWork(ApplicationDBContext db)
        {
            this._db = db;
            this.Category = new CategoryRepository(_db);
            this.VacanteStandard = new VacanteStandard(_db);
            this.lastMinute = new LastMinuteRepository(_db);
            this.countries = new Countries(_db);
            this.ShoppingCart = new ShoppingCart(_db);
            this.applicationUser = new ApplicationUser(_db);
            this.orderHeaderRepository = new OrderHeader(_db);
            this.detailsOrderRepository = new OrderDetails(_db);

        }



        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

