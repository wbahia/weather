
using Weather.Domain.Interfaces;

namespace Weather.DAL.Base
{
    public class RepositoryFactory<T> where T : class
    {
        #region Métodos Públicos
        public static IRepository<T> GetRepository(WeatherContext context)
        {
            return new GenericRepository<T>(context);
        }
        #endregion
    }
}
