using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MIM_IITB.Data.Entities;
using MIM_IITB.Data.Interface;
using MIM_IITB.Data.Repository;
using MIM_IITB.Helpers;
using RestSharp.Newtonsoft.Json.NetCore;

namespace MIM_IITB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration["database"]));
            services.AddTransient<IFoodRepository, FoodRepository>();
            services.AddTransient<IFoodTypeRepository, FoodTypeRepository>();
            services.AddTransient<IAuthUserRepository, AuthUserRepository>();
            services.AddTransient<IIntakeRepository, IntakeRepository>();
            services.AddTransient<IIntakeBatchRepository, IntakeBatchRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IVendorRepository, VendorRepository>();
            
            services.AddControllers().AddNewtonsoftJson(option=>
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() {Title = "MIM-IITB", Version = Configuration["version"]});
                c.OperationFilter<AddAuthenticationHeaderParameter>();
            });
            
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthenticationMiddleware();
            
            app.UseSwagger();
            app.UseSwaggerUI(
                c => { c.SwaggerEndpoint("/swagger/v1/swagger.json",
                $"{Configuration["ProjectName"]} {Configuration["Version"]}"); });
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}