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
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Text;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

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
                        mysqlOptions.MigrationsAssembly("Ncc.China.Services.Identity.Api");
                    })
            );

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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters{
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = Configuration["Tokens:Audience"],
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                            Configuration["Tokens:SecurityKey"])),
                    };
                    options.Events = new JwtBearerEvents{
                        OnChallenge  = (context) => {
                            var body = JsonConvert.SerializeObject(new {
                                code = 1,
                                message = "failed:unauthorized"
                            });
                            context.HandleResponse();
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";
                            return context.Response.WriteAsync(body);
                        },
                        OnTokenValidated = (context) => {
                            var sub = context.Principal.Claims.FirstOrDefault(_ =>
                                _.Type.Equals(System.Security.Claims.ClaimTypes.NameIdentifier))?.Value;
                            context.HttpContext.Items.Add("username", sub);
                            return Task.CompletedTask;
                        }
                    };
                });
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

            // use default policy
            app.UseCors();

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<IdentityDbContext>();

                // true is created and false is already existed
                // if (!context.Database.EnsureCreated())
                // {
                //     // if (context.Database.GetPendingMigrations().Any())
                //     // {
                //     //     context.Database.Migrate();
                //     // }
                // }

                context.Database.Migrate();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
