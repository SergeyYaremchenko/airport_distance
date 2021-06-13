using FluentValidation;
using FluentValidation.Results;

namespace AirportDistance.Shared.Validators {
    public class BaseValidator<T> : AbstractValidator<T> {
        /// <summary>
        ///     Will be called before each Validate
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns>Error if validating object is null</returns>
        protected override bool PreValidate(ValidationContext<T> context, ValidationResult result) {
            if (context.InstanceToValidate != null) {
                return base.PreValidate(context, result);
            }

            result.Errors.Add(new ValidationFailure("model", "model is null"));
            return false;
        }
    }
}