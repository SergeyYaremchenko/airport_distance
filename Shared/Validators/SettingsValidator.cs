using System.IO;
using AirportDistance.Shared.Models;
using FluentValidation;

namespace AirportDistance.Shared.Validators {
    public class SettingsValidator : BaseValidator<Settings> {
        public SettingsValidator() {
            RuleFor(x => x.AirportsCsvFilePath)
                .NotNull().NotEmpty()
                .WithMessage(_ => $"{nameof(Settings.AirportsCsvFilePath)}: CSV file path cannot be empty")
                .WithErrorCode("E_CSV_FILE_PATH_EMPTY");
            RuleFor(x => x.AirportsCsvFilePath)
                .NotNull().NotEmpty().Must(File.Exists)
                .WithMessage(x => $"{nameof(Settings.AirportsCsvFilePath)}: CSV file cannot be found at path: {x.AirportsCsvFilePath}")
                .WithErrorCode("E_CSV_FILE_NOT_FOUND");
        }
    }
}