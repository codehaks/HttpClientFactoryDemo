using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Common;

namespace MyApp.Controllers
{
    public class FactoryController : Controller
    {
        //private readonly IHttpClientFactory _factory;
        //public FactoryController(IHttpClientFactory factory)
        //{
        //    _factory = factory;
        //}
        //[Route("api/factory")]
        //public async Task<IActionResult> Factory()
        //{

        //    var client = _factory.CreateClient("demo");
        //    var result=await client.GetAsync("/");
        //    result.Dispose();
        //    return Ok();
        //}

        private readonly GoogleClient _client;
        public FactoryController(GoogleClient client)
        {
            _client = client;
        }
        [Route("api/factory")]
        public async Task<IActionResult> Factory()
        {

            await _client.Get();
            return Ok();
        }
    }
}
