using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FactoryWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory _factory;
        public Worker(ILogger<Worker> logger, IHttpClientFactory factory)
        {
            _logger = logger;
            _factory = factory;

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            for (int i = 1; i < 11; i++)
            {
                var client = _factory.CreateClient();
                
                await client.GetAsync("https://codehaks.com");

                //using var client = new HttpClient();
                //await client.GetAsync("https://codehaks.com");

                _logger.LogInformation($"{i} - Connection established");

            }

            _logger.LogInformation("Done!");

            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //    await Task.Delay(1000, stoppingToken);
            //}
        }
    }
}
