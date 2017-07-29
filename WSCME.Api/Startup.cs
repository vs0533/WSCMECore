﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WSCME.Data;
using WSCME.Data.Infrastructure;
using WSCME.Domain.Entities.Identity;
using IdentityServer4.Validation;
using WSCME.Service;
using IdentityServer4.Services;

namespace WSCME.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<CMEDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer"))
                );

            services.AddIdentity<CMEUser, CMERole>()
                .AddEntityFrameworkStores<CMEDbContext>()
                .AddDefaultTokenProviders();


            

            #region 跨域设置
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:1841").AllowAnyMethod().AllowAnyHeader());
            });
            #endregion

            #region 注册异步提交服务
            services.AddScoped<IUnitOfWorkAsync, UnitOfWorkAsync>();


            services.AddScoped<ITrainingCentreCategoryRepository, TrainingCentreCategoryRepository>(); 
            #endregion

            services.AddMvc();

            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryPersistedGrants()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiReSource())
                .AddInMemoryClients(Config.GetClients())
                .AddAspNetIdentity<CMEUser>();

            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IProfileService, ProfileService>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIdentity();
            app.UseIdentityServer();

            app.UseCors("AllowSpecificOrigin");
            
            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost:5000",
                RequireHttpsMetadata = false,
                ApiName = "api1"
            });

            app.UseMvc();

        }
    }
}
