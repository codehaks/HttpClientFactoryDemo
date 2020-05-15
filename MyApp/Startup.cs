using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApp.Common;
using MyApp.Data;
using System;
using System.Net.Http;

namespace MyApp
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>
                (options => options.UseSqlite("Data Source=app.sqlite"));

            services.AddControllers();

            services.AddHttpClient("demo", client =>
            {
                client.BaseAddress = new Uri("https://google.com/");
                client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactoryTesting");

            }).SetHandlerLifetime(TimeSpan.FromMinutes(10));

            services.AddHttpClient<GoogleClient>();
            

            services.AddRazorPages()
                .AddRazorRuntimeCompilation();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();

            });
        }
    }
}
