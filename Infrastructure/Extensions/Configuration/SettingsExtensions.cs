using System;
using AirportDistance.Shared.Models;
using AirportDistance.Shared.Validators;
using Microsoft.Extensions.Configuration;
using FluentValidation;

namespace AirportDistance.Infrastructure.Extensions.Configuration {
    public static class SettingsExtensions {
        /// <summary>
        ///     Validates Settings
        /// </summary>
        /// <param name="configuration">Configuration</param>
        /// <exception cref="ArgumentNullException">If configuration is empty</exception>
        public static void ValidateSettings(this IConfiguration configuration) {
            var config = configuration.GetSection(nameof(Settings)).Get<Settings>();

            if (config is null) {
                throw new ArgumentNullException(nameof(configuration), $"Can't start: configuration section {nameof(Settings)} is not set or empty");
            }

            var configValidator = new SettingsValidator();

            configValidator.ValidateAndThrow(config);
        }
    }
}