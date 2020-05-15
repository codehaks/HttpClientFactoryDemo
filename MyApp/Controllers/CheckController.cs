using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Controllers
{
    public class CheckController : Controller
    {
        
        [Route("api/check")]
        public async Task<IActionResult> Index()
        {
            using var client = new HttpClient();
            await client.GetAsync("http://google.com");
            return Ok();
        }
       
    }
}
