using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TestTask.API.Configuration;
using TestTask.Data;

namespace TestTask.API {
    public class Startup {
        public Startup(IConfiguration configuration) {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services
                .AddDbContext(_configuration)
                .AddServices()
                .AddMappingProfiles<AssemblyInfo>()
                .AddSwaggerGen()
                .AddControllers()
                .AddNewtonsoftJson(opt => {
                    opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.ContractResolver = new DefaultContractResolver {
                        NamingStrategy = new SnakeCaseNamingStrategy(),
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseSwagger();

            app.UseSwaggerUI(
                opt => {
                    opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Test task v1");
                    opt.RoutePrefix = string.Empty;
                }
            );

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("AllowAll");

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}