using System;
using System.Linq.Expressions;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Repository.IRepository;
using Vacante.DataAccess.Repository.Repository;
using VacanteAPP.Models;
using VacanteAPP.Models.ViewModels;

namespace Vacante.DataAccess.Repository
{
    public class VacanteStandard : Repository<VacanteAPP.Models.VacanteStandard>, IVacanteStandardRepository
    {

        protected ApplicationDBContext _db;
        public VacanteStandard(ApplicationDBContext db) : base(db)
        {
            this._db = db;
        }
        public void Update(VacanteAPP.Models.VacanteStandard vacanteStandard)
        {
            _db.Update(vacanteStandard);
        }

        public void Update(VacanteStandardVM obj)
        {
            _db.Update(obj.vacanteStandard);

        }
    }
}

