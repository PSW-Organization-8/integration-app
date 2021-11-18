using IntegrationClassLib;
using IntegrationClassLib.Parthership.Repository;
using IntegrationClassLib.Parthership.Service;
using IntegrationClassLib.Pharmacy.Repository.PharmacyRepo;
using IntegrationClassLib.Pharmacy.Repository.MedicationRepo;
using IntegrationClassLib.Pharmacy.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntegrationClassLib.Parthership.Service.Interface;

namespace IntegrationAPI
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

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IntegrationAPI", Version = "v1" });
            });

            services.AddDbContext<MyDbContext>(options => options.UseNpgsql(x => x.MigrationsAssembly("IntegrationAPI")));
            services.AddTransient<IPharmacyRepository, PharmacyRepository>();
            services.AddTransient<IObjectionRepository,ObjectionRepository>();
            services.AddTransient<IResponseRepository, ResponseRepository>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<IMedicationRepository, MedicationRepository>();
            services.AddScoped<PharmacyService>();
            services.AddScoped<MedicationService>();
            services.AddScoped<ObjectionService>();
            services.AddScoped<ResponseService>();
            services.AddScoped<IReceivingNewsService, ReceivingNewsRabbitMQService>();
            services.AddScoped<IActionsAndNewsService, ActionsAndNewsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IntegrationAPI v1"));
            }

            app.UseRouting();
            app.UseCors("MyPolicy");

            app.UseCors("MyPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
