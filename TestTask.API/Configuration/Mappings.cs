using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace TestTask.API.Configuration {
    public static class Mappings {
        public static IServiceCollection AddMappingProfiles<TAssembly>(
            this IServiceCollection services
        ) {
            var types = typeof(TAssembly).Assembly.GetTypes();

            var automapperProfiles = types.Where(type => type.IsSubclassOf(typeof(Profile))).ToList();

            var mapperConfiguration = new MapperConfiguration(cfg =>
                automapperProfiles.ForEach(profile => cfg.AddProfile(profile))
            );

            var mapper = mapperConfiguration.CreateMapper();

            return services.AddSingleton(mapper);
        }
    }
}