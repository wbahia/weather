using System.Collections.Generic;
using System.Linq;
using Weather.BLL.Base;
using Weather.Domain.Model;
using Weather.Proxy;
using Weather.Proxy.Client;

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

            //ClientConfig.ApiUrl = "http://api.openweathermap.org/data/2.5";
            //ClientConfig.ApiKey = "a75f4b55aed47dd3b7b65f58a242855f";
                       
            //var result = CurrentWeather.GetByCityName("Rio de Janeiro");

            return listaCidades;


           
        }
    }
}
