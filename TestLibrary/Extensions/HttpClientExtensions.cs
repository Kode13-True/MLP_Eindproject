﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MLP_TestLibrary.Extensions
{
    public static class HttpClientExtensions
    {
        public static HttpResponseMessage PostJson(this HttpClient client, string requestUri, object content)
        {
            var settings = new JsonSerializerSettings();
            //settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            var contentString = JsonConvert.SerializeObject(content, settings);
            return client.PostAsync(requestUri, new StringContent(contentString, Encoding.UTF8, "application/json")).Result;
        }
    }
}
