using System.Collections.Generic;
using System.Linq;
using Weather.BLL.Base;
using Weather.Domain.Model;
using Weather.Proxy;

namespace Weather.BLL.Manager
{
    public class CidadeManager
    {
        public List<Cidade> ObterCidades()
        {
            List<Cidade> listaCidades = new List<Cidade>();
            using(var unitOfWork = new UnitOfWorkManager())
            {
                listaCidades = unitOfWork.GetManager<Cidade>().GetBy().ToList();
            }

            var teste = new Servico().GetForecastAsync("Blumenau");
            return listaCidades;


           
        }
    }
}
