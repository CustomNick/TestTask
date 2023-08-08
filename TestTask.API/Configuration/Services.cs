using Microsoft.Extensions.DependencyInjection;
using TestTask.Core.Services;

namespace TestTask.API.Configuration {
    public static class Services {
        public static IServiceCollection AddServices(
            this IServiceCollection services
        ) {
            return services
                .AddScoped<MeasuringPointService>()
                .AddScoped<MeteringDeviceService>()
                .AddScoped<ConsumerObjectService>()
                ;
        }
    }
}