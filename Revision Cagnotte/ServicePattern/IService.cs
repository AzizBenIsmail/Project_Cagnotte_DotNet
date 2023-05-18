using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ServicePattern
{
    public interface IService<T> : IDisposable where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(int id);
        T GetById(string id);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null);
        T Get(Expression<Func<T, bool>> where);
        void Commit();
    }
}