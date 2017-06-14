using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiFetcher
{
    public static class WebClientFactory
    {
        public static WebClient Create()
        {
            var client = new WebClient();

            client.Headers.Add("X-Application-Name:ApiFetcher");
            client.Encoding = Encoding.UTF8;

            return client;
        }
    }
}
