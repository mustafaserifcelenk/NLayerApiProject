using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLayerApiProject.Core.Repository;
using NLayerApiProject.Core.Service;
using NLayerApiProject.Core.UnitOfWork;
using NLayerApiProject.Data;
using NLayerApiProject.Data.Repositories;
using NLayerApiProject.Data.UnitOfWorks;
using NLayerApiProject.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NLayerApiProject.API.Filters;
using Microsoft.AspNetCore.Diagnostics;
using NLayerApiProject.API.DTOs;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NLayerApiProject.Api.Extensions;

namespace NLayerApiProject.Api
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
            services.AddAutoMapper(typeof(Startup));

            // DI nesnesi alan filter'� startup'da tan�mlama, bunun sebebi DI nesnesi interface'i ald���ndan startup'a kaydetme gereklili�i
            services.AddScoped<NotFoundFilter>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service.Services.Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
                {
                    o.MigrationsAssembly("NLayerApiProject.Data");
                });
            });

            // Global olarak filtre tan�mlama
            // services.AddControllers(o=> {
            //     o.Filters.Add(new ValidationFilter());
            // });
            services.AddControllers();
            services.Configure<ApiBehaviorOptions>(options =>
            {
                // Art�k invalid filter�n� sen kontrol etme, ben kontrol edece�im
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NLayerApiProject.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NLayerApiProject.Api v1"));
            }

            // Global hata y�netimi
            app.UseCustomException();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
