using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static T GetContent<T>(this HttpResponseMessage responseMessage)
        {
            string contentString = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return (T)JsonConvert.DeserializeObject(contentString, typeof(T));
        }
    }
}
