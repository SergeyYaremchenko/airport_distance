using System.IO;
using AirportDistance.Shared.Models;
using FluentValidation;

namespace AirportDistance.Shared.Validators {
    public class ServiceConfigurationValidator : BaseValidator<ServiceConfiguration> {
        public ServiceConfigurationValidator() {
            RuleFor(x => x.AirportsCsvFilePath)
                .NotNull().NotEmpty()
                .WithMessage(_ => $"{nameof(ServiceConfiguration.AirportsCsvFilePath)}: CSV file path cannot be empty")
                .WithErrorCode("E_CSV_FILE_PATH_EMPTY");
            RuleFor(x => x.AirportsCsvFilePath)
                .NotNull().NotEmpty().Must(File.Exists)
                .WithMessage(x => $"{nameof(ServiceConfiguration.AirportsCsvFilePath)}: CSV file cannot be found at path: {x.AirportsCsvFilePath}")
                .WithErrorCode("E_CSV_FILE_NOT_FOUND");
        }
    }
}