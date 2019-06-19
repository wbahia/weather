using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Proxy
{
    public static class ClientConfig
    {

        public static string ApiKey = null;
        public static string ApiUrl = "http://api.openweathermap.org/data/2.5";

        public static void SetApiKey(string apiKey)
        {
            ApiKey = apiKey;
        }

        public static void SetApiUrl(string apiUrl)
        {
            ApiUrl = apiUrl;
        }


    }
}
