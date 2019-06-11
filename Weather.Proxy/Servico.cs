using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Weather.Proxy
{
    public class Servico
    {
        const string KEY = "a75f4b55aed47dd3b7b65f58a242855f";

        public async Task GetForecastAsync(string cidade)
        {

            using (var client = new HttpClient())
            {
               
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");
                
                var result = await client.GetAsync("http://openweathermap.org/data/2.5/weather?q=" + cidade + "&APPID=" + KEY);

            }

        }

    }
}
