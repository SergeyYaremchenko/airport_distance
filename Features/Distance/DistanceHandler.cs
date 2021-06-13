using System;
using System.Collections.Generic;
using AirportDistance.Shared.Models;
using AirportDistance.Shared.Validators;
using FluentValidation;

namespace AirportDistance.Features.Distance {
    public class DistanceHandler {
        private readonly IReadOnlyDictionary<string, AirportRecord> _airports;
        private const int EarthRadius = 6371;
        private const double MileToKmRatio = 0.621371;

        public DistanceHandler(IReadOnlyDictionary<string, AirportRecord> airports) {
            _airports = airports;
        }

        public double GetDistanceInMiles(DistanceRequest r) {
            if (r is null) {
                throw new ArgumentNullException(nameof(r));
            }
            var from = _airports[r.From!.ToUpperInvariant()];
            var to = _airports[r.To!.ToUpperInvariant()];

            return CalculateDistance(from.Latitude, from.Longitude, to.Latitude, to.Longitude);
        }

        private static double CalculateDistance(double lat1, double lng1, double lat2, double lng2) {
            var f1 = lat1 * Math.PI / 180;
            var f2 = lat2 * Math.PI / 180;

            var deltaF = (lat2 - lat1) * Math.PI / 180;
            var deltaLambda = (lng2 - lng1) * Math.PI / 180;

            var a = Math.Sin(deltaF / 2) * Math.Sin(deltaF / 2) +
                    Math.Cos(f1) * Math.Cos(f2) *
                    Math.Sin(deltaLambda / 2) * Math.Sin(deltaLambda / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var d = EarthRadius * c;

            return d * MileToKmRatio;
        }
    }
    
    public class DistanceRequest {
        /// <summary>
        /// IATA Code of source airport
        /// </summary>
        /// <example>LEV</example>
        public string? From { get; set; }

        /// <summary>
        /// IATA Code of destination airport
        /// </summary>
        /// <example>RMS</example>
        public string? To { get; set; }
    }
    
    public class DistanceRequestValidator : BaseValidator<DistanceRequest> {
        public DistanceRequestValidator(IReadOnlyDictionary<string, AirportRecord> airports) {
            RuleFor(x => x.From).NotNull().SetValidator(new AirportExistsValidator(airports));
            RuleFor(x => x.To).NotNull().SetValidator(new AirportExistsValidator(airports));
        }
            
        private class AirportExistsValidator : BaseValidator<string?> {
            public AirportExistsValidator(IReadOnlyDictionary<string, AirportRecord> airports) {
                RuleFor(x => x).NotNull().NotEmpty().Must(x => airports.ContainsKey(x!.ToUpperInvariant())).WithMessage(x => $"Unknown airport {x}").WithErrorCode("E_AIRPORT_NOT_FOUND");
            }
        }
    }
}