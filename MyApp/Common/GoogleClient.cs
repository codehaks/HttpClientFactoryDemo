using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyApp.Common
{
    public class GoogleClient
    {

        public HttpClient Client { get; }

        public GoogleClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://google.com/");
            Client = client;
        }

        public async Task<bool> Get()
        {
            await Client.GetAsync("/");
            return true;
        }

    }
}
