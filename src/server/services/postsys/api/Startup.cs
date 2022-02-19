using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Ncc.China.Services.Postsys.Data;
using Ncc.China.Services.Postsys.Repository;
using Newtonsoft.Json;
using OpenTracing;
using OpenTracing.Util;

namespace Ncc.China.Services.Postsys.Api
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

            services.AddSingleton<ITracer>(sp =>
            {
                var loggerFactory = sp.GetService<ILoggerFactory>();
                var config = Jaeger.Configuration.FromIConfiguration(loggerFactory, Configuration);
                // sampler port 5778/http
                // reporter port 6831/udp
                var tracer = config.GetTracer();
                GlobalTracer.Register(tracer);
                return tracer;
            });
            services.AddOpenTracing();


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

            services.Configure<MongoSettings>(options => {
                options.ConnectionString = Configuration["MongoSettings:ConnectionString"];
                options.DatabaseName = Configuration["MongoSettings:DatabaseName"];
            });



            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
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

            app.UseStatusCodePages(builder => {
                builder.Run(async ctx => {
                    if (ctx.Response.StatusCode == StatusCodes.Status404NotFound) {
                        ctx.Response.ContentType = "application/json; charset=utf-8";
                        await ctx.Response.WriteAsync("{\"error\": \"failed:not found your url\"}");
                    }
                });
            });

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
