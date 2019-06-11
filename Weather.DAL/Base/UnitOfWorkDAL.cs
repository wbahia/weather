using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Weather.Domain.Interfaces;

namespace Weather.DAL.Base
{
    public class UnitOfWorkDAL : IDisposable, IUnitOfWork
    {
        #region Atributo

        private WeatherContext _context;

        #endregion

        #region Construtor

        public UnitOfWorkDAL()
        {
            _context = new WeatherContext();
        }

        #endregion

        #region Metodos

        public IRepository<T> GetRepository<T>() where T : class
        {
            return RepositoryFactory<T>.GetRepository(_context);
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entidade do tipo \"{0}\" no estado \"{1}\" tem os seguintes erros de validação:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Erro: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception )
            {
                throw;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DbContext GetContext()
        {
            return WeatherContext.Create();
        }

        #endregion
    }

}
