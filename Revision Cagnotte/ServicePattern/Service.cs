using Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ServicePattern
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        static IDataBaseFactory factory = new DataBaseFactory();
        //static IUnitOfWork utwk = new UnitOfWork(factory);
       
            protected readonly IUnitOfWork utwk;
            public Service(IUnitOfWork utwk)
            {
                this.utwk = utwk;
            }

        public virtual void Add(TEntity entity)
        {
            utwk.getRepository<TEntity>().Add(entity);
        }
        public virtual void Update(TEntity entity)
        {
            utwk.getRepository<TEntity>().Update(entity);
        }
        public virtual void Delete(TEntity entity)
        {
            utwk.getRepository<TEntity>().Delete(entity);
        }
        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            utwk.getRepository<TEntity>().Delete(where);
        }
        public virtual TEntity GetById(int id)
        {
            return
            utwk.getRepository<TEntity>().GetById(id);
        }
        public virtual TEntity GetById(string id)
        {
            return
            utwk.getRepository<TEntity>().GetById(id);
        }
        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter = null)
        {
            return utwk.getRepository<TEntity>().GetMany(filter);
        }
        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            return utwk.getRepository<TEntity>().Get(where);
        }
        public virtual void Dispose()
        {
            utwk.Dispose();
        }
        public void Commit()
        {
            try
            {
                utwk.Commit();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
