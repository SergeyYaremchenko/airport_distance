using System.Collections.Generic;
using AirportDistance.Features.Distance;
using AirportDistance.Shared.Models;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AirportDistance.Infrastructure.Extensions.ServiceCollection {
    public static class RegisterServicesExtension {
        /// <summary>
        ///     Register services in ServiceCollection
        /// </summary>
        /// <param name="serviceCollection">ServiceCollection</param>
        public static void RegisterServices(this IServiceCollection serviceCollection) {

            serviceCollection.AddSingleton(provider => {

                var settings = provider.GetRequiredService<IOptions<Settings>>();

                return DistanceLoader.GetRecords(settings.Value);
            });

            serviceCollection.AddTransient<IValidator<Distance.Request>, Distance.RequestValidator>(provider => {
                var airports = provider.GetRequiredService<IReadOnlyDictionary<string, AirportRecord>>();
                
                return new Distance.RequestValidator(airports);
            });
            serviceCollection.AddScoped<Distance>();
        }
    }
}