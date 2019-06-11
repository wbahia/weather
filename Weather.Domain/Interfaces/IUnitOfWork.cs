using System;
using System.Data.Entity;

namespace Weather.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext GetContext();
        void Commit();
    }
}
