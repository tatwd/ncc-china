using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ncc.China.Services.Identity.Data;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Ncc.China.Services.Identity.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            /* Server=localhost;Database=test;User=root;Password=test123; */
            var db = Configuration.GetConnectionString("IdentityDb");
            services.AddDbContextPool<IdentityDbContext>(
                options => options.UseMySql(db,
                    mysqlOptions =>
                    {
                        mysqlOptions.ServerVersion(new Version(8, 0, 12), ServerType.MySql);
                    })
            );
        }

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

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<IdentityDbContext>();

                // true is created and false is already existed
                if (!context.Database.EnsureCreated())
                {
                    // if (context.Database.GetPendingMigrations().Any())
                    // {
                    //     context.Database.Migrate();
                    // }
                }
            }

            // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
