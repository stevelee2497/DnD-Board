using AutoMapper;
using DnD_Board.API.Filters;
using DnD_Board.Data.Contexts;
using DnD_Board.IRepositories;
using DnD_Board.IServices;
using DnD_Board.Repositories;
using DnD_Board.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace DnD_Board.API
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
            services.AddControllers();
            services.AddSingleton(Configuration);
            services.AddMvc(MvcOptions).AddNewtonsoftJson(JsonOption).SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddSwaggerGen(SwaggerConfigs);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<EfDbContext>(DbContextOptions);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(EnpointConfigs);

            app.UseSwagger();

            app.UseSwaggerUI(SwaggerUIConfigs);

            DbInitializer.Initialize(app.ApplicationServices.CreateScope().ServiceProvider);
        }

        private void JsonOption(MvcNewtonsoftJsonOptions options)
        {
            options.SerializerSettings.Formatting = Formatting.Indented;
            options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate;
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private void MvcOptions(MvcOptions options)
        {
            options.Filters.Add<ExceptionFilter>();
            options.Filters.Add<ValidatorActionFilter>();
        }

        private void DbContextOptions(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        private void SwaggerConfigs(SwaggerGenOptions c)
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Server API", Version = "v1" });
        }

        private void SwaggerUIConfigs(SwaggerUIOptions c)
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty;
        }

        private void EnpointConfigs(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllers();
        }
    }
}