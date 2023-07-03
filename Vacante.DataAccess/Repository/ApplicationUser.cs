using System;
using System.Linq.Expressions;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Repository.IRepository;
using Vacante.DataAccess.Repository.Repository;
using VacanteAPP.Models;
using VacanteAPP.Models.ViewModels;

namespace Vacante.DataAccess.Repository
{
    public class ApplicationUser : Repository<VacanteAPP.Models.ApplicationUser>, IApplicationUserRepository
    {

        protected ApplicationDBContext _db;
        public ApplicationUser(ApplicationDBContext db) : base(db)
        {
            this._db = db;
        }

    }
}

