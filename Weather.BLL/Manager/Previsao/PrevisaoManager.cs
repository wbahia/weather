using System;
using Weather.Proxy;
using Weather.Proxy.Client;
using Weather.Proxy.Model;

namespace Weather.BLL.Manager
{
    public class PrevisaoManager
    {

        public Result<FiveDaysForecastResult> ObterPrevisao(int idAPI)
        {
            try
            {
                //consulta a previsao na api
                ClientConfig.ApiUrl = "http://api.openweathermap.org/data/2.5";
                ClientConfig.ApiKey = "a75f4b55aed47dd3b7b65f58a242855f";
                var result = FiveDaysForecast.GetByCityId(idAPI);

                return result;

            }
            catch (Exception)
            {
                return new Result<FiveDaysForecastResult>();
            }

        }
    }
}
