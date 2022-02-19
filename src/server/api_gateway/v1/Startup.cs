using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.IO;
using Jaeger;
using OpenTracing;
using OpenTracing.Util;

namespace Ncc.China.ApiGateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options => {
                // add default policy to allow all
                options.AddPolicy(options.DefaultPolicyName,
                    builder => {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });

                // others here
            });

            services.AddOcelot(new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
                .Build());

            services.AddSingleton<ITracer>(sp =>
            {
                var loggerFactory = sp.GetService<ILoggerFactory>();
                var config = new Configuration("NccChinaApiGateway", loggerFactory);
                // sampler port 5778/http
                // reporter port 6831/udp
                var tracer = config.GetTracer();
                GlobalTracer.Register(tracer);
                return tracer;
            });

            services.AddOpenTracing();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors();

            // app.UseHttpsRedirection();
            app.UseMvc();
            app.UseOcelot().Wait();
        }
    }
}
