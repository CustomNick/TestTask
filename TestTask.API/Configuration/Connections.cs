using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestTask.API.Configuration {
    public static class Connections {
        public static IServiceCollection AddDbContext(
            this IServiceCollection services,
            IConfiguration configuration
        ) {
            var connString = configuration.GetConnectionString("Default");

            return services
                .AddDbContext<TestTask.Core.EF.TestTaskContext>(
                    opt => opt
                        .UseNpgsql(
                            connString,
                            dbOpt => dbOpt.MigrationsAssembly("TestTask.API")
                        )
                );
        }
    }
}