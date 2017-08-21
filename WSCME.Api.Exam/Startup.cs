using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WSCME.Data;
using WSCME.Service;
using IdentityServer4.Services;
using IdentityServer4.Validation;

namespace WSCME.Api.Exam
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
                     options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer_CMEDB"))
                )
            .AddDbContext<CMEExamDbContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("SqlServer_EXAM"))
                ).AddUnitOfWork<CMEExamDbContext, CMEDbContext>();


            #region 跨域设置
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:1841", "http://192.168.4.102:5000").AllowAnyMethod().AllowAnyHeader());
            });
            #endregion

            services.AddMvc();

            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryPersistedGrants()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiReSource())
                .AddInMemoryClients(Config.GetClients());

            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IProfileService, ProfileService>();

            services.AddScoped<ITESTLibraryCategoryServices, TESTLibraryCategoryService>();
            services.AddScoped<IUnitAccountServices, UnitAccountServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors("AllowSpecificOrigin"); //跨域必须设置在这里 一开始这里 切记


            app.UseIdentityServer();



            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost:5001",
                RequireHttpsMetadata = false,
                ApiName = "api1"
            });

            app.UseMvc();
        }
    }
}
