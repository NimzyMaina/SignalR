using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace SignalR
{
    class Startup
    {
        public void ConfigureServices(
            IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("fiver",
                    policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });

            services.AddSignalR(); // <-- SignalR
        }

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env)
        {
            app.UseCors("fiver");

            app.UseSignalR(routes =>  // <-- SignalR
            {
                routes.MapHub<ReportsPublisher>("reportsPublisher");
            });
        }
    }
}
