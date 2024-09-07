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
            for (int i = 1; i <= 100; i++)
            {
                if (stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation("Operation cancelled.");
                    break;
                }

                var client = _factory.CreateClient();

                await client.GetAsync("https://codehaks.com", stoppingToken);
                _logger.LogInformation($"{i} - Connection established");

                await Task.Delay(1000, stoppingToken); // Wait for 1 second
            }

            _logger.LogInformation("Done!");
        }
    }
}
