using System;
using Weather.Proxy.Model;
using Weather.Proxy.Util.Api;
using Weather.Proxy.Util.Data;

namespace Weather.Proxy.Client
{
    public static class FiveDaysForecast
    {

        // fixando a lingua e sistema metrico
        public const string LANG = "pt";
        public const string UNIT = "metric";

        public static Result<FiveDaysForecastResult> GetByCityName(String city)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(city))
                    return new Result<FiveDaysForecastResult>(null, false, "É preciso fornecer uma cidade.");
                var response = ApiClient.GetResponse("/forecast?q=" + city + "&lang=" + LANG + "&units=" + UNIT);

                return Deserializer.GetWeatherForecast(response);
            }
            catch (Exception ex)
            {
                return new Result<FiveDaysForecastResult> { Items = null, Success = false, Message = ex.Message };
            }
        }

        public static Result<FiveDaysForecastResult> GetByCityId(int id)
        {
            try
            {
                if (0 > id) return new Result<FiveDaysForecastResult>(null, false, "É preciso fornecer uma cidade válida.");
                var response = ApiClient.GetResponse("/forecast?id=" + id + "&lang=" + LANG + "&units=" + UNIT);
                return Deserializer.GetWeatherForecast(response);
            }
            catch (Exception ex)
            {
                return new Result<FiveDaysForecastResult> { Items = null, Success = false, Message = ex.Message };
            }
        }

    }
}
