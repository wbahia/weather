using System;
using Weather.DAL.Base;
using Weather.Domain.Interfaces;

namespace Weather.BLL.Base
{
    public class UnitOfWorkManager : IDisposable
    {
        #region Atributos

        private UnitOfWorkDAL _unitOfWorkDAL;
        protected bool _disposed;

        #endregion

        #region Construtor

        public UnitOfWorkManager()
        {
            _unitOfWorkDAL = new UnitOfWorkDAL();
        }

        #endregion

        #region Propriedade

        public IManager<T> GetManager<T>() where T : class
        {
            return new BaseManager<T>(_unitOfWorkDAL);
        }

        #endregion

        #region Métodos Públicos 


        public void Commit()
        {
            _unitOfWorkDAL.Commit();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _unitOfWorkDAL.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DateTime GetHoraServidor()
        {
            return DateTime.Now;

        }

        #endregion

        #region Métodos Privados

        #endregion
    }
}
