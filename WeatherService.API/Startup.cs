using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using WeatherService.API.Extensions;
using WeatherService.API.Infrastructure;

namespace WeatherService.API
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
            services.AddCors(opt => opt.AddPolicy("corsPolicy", builder =>
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()));

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.Converters.Add(new StringEnumConverter()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WeatherService.API", Version = "v1" });
            });

            services.AddSwaggerGenNewtonsoftSupport();

            services.RegisterRepositories();

            services.RegisterServices();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<RepositoryDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("corsPolicy");

            app.UseCorrelation();

            app.UseCustomException();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherService.API v1"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
