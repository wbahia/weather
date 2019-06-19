﻿#region

using System;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json.Linq;

#endregion

namespace Weather.Proxy.Util.Api
{
    public static class ApiClient
    {
        
        
        public static JObject GetResponse(String queryString)
        {
            using (var client = new WebClient())
            {
                var apiKey = ClientConfig.ApiKey;
                var apiUrl = ClientConfig.ApiUrl;
                Trace.WriteLine("<HTTP - GET - " + queryString + " >");
                string url;
                if (!string.IsNullOrEmpty(apiKey))
                    url = apiUrl + queryString + "&APPID=" + apiKey;
                else
                    url = apiUrl + queryString;

                var response = client.DownloadString(url);
                var parsedResponse = JObject.Parse(response);
                return parsedResponse;
            }
        }
    }
}