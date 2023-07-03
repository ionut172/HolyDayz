using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Vacante.DataAccess.Data;
using Vacante.DataAccess.Repository.IRepository;
namespace Vacante.DataAccess.Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDBContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
            _db.Countries.Include(u => u.CountryName).Include(u => u.CountryId);

        }

        void IRepository<T>.Add(T entity)
        {
            dbSet.Add(entity);
        }

        T IRepository<T>.Get(System.Linq.Expressions.Expression<Func<T, bool>> filtru, string? includeProprieties = null, bool tracked = false)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filtru);
            if (includeProprieties != null)
            {
                foreach (var includeProp in includeProprieties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();
        }

        IEnumerable<T> IRepository<T>.GetAll(string? includeProprieties = null)
        {
            IQueryable<T> query = dbSet;

            if (includeProprieties != null)
            {
                foreach (var includeProp in includeProprieties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        IEnumerable<T> IRepository<T>.GetAllLinq(Expression<Func<T, bool>> filtru, string? includeProprieties)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filtru);
            if (includeProprieties != null)
            {
                foreach (var includeProp in includeProprieties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query.Include(includeProp);
                }
            }
            return query.ToList();
        }

        void IRepository<T>.Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        void IRepository<T>.RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}

