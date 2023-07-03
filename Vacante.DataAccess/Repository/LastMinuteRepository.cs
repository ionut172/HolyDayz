using System;
using System.Linq.Expressions;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Repository;
using Vacante.DataAccess.Repository.IRepository;
using Vacante.DataAccess.Repository.Repository;
using VacanteAPP.Models;

namespace Vacante.DataAccess
{
    public class LastMinuteRepository : Repository<LastMinute>, ILastMinuteRepository
    {
        private ApplicationDBContext _db;
        public LastMinuteRepository(ApplicationDBContext db) : base(db)
        {
            this._db = db;
        }

        public void Update(LastMinute lastMinute)
        {
            _db.LastMinute.Update(lastMinute);

        }
    }
}

