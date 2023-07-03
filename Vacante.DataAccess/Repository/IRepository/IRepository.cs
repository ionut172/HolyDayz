using System;
using System.Linq.Expressions;

namespace Vacante.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // T - Categorie

        T Get(Expression<Func<T, bool>> filtru, string? includeProprieties = null, bool tracked = false);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        IEnumerable<T> GetAll(string? includeProprieties = null);
        IEnumerable<T> GetAllLinq(Expression<Func<T, bool>> filtru, string? includeProprieties);
    }
}

