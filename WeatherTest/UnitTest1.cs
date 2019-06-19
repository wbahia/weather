using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Weather.Proxy;
using Weather.Proxy.Client;

namespace WeatherTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetCurrentWeatherByCityNameTest()
        {
            
            ClientConfig.ApiUrl = "http://api.openweathermap.org/data/2.5";
            ClientConfig.ApiKey = "a75f4b55aed47dd3b7b65f58a242855f";


            
            var result = CurrentWeather.GetByCityName("Rio de Janeiro");
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Item);
                                   
        }
    }
}
