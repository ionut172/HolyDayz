using System;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Repository.IRepository;
using Vacante.DataAccess.Repository.Repository;
using VacanteAPP.Models;

namespace Vacante.DataAccess.Repository
{
    public class Countries : Repository<VacanteAPP.Models.Countries>, ICountriesRepository
    {
        private ApplicationDBContext _db;
        public Countries(ApplicationDBContext db) : base(db)
        {
            this._db = db;
        }


        public void Update(VacanteAPP.Models.Countries countries)
        {
            _db.Countries.Update(countries);
        }


    }
}

