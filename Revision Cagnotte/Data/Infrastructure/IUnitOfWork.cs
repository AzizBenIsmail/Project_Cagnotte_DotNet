using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        //void Dispose(); Hidden from IDisposable interface
        IRepositoryBase<T> getRepository<T>() where T : class;
    }
}