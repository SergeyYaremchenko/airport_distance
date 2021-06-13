using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using AirportDistance.Shared.Models;
using CsvHelper;

namespace AirportDistance.Features.Distance {
    public static class DistanceLoader {
        public static IReadOnlyDictionary<string, AirportRecord> GetRecords(ServiceConfiguration serviceConfiguration) {
            if (serviceConfiguration is null) {
                throw new ArgumentNullException(nameof(serviceConfiguration));
            }
            
            using var reader = new StreamReader(serviceConfiguration.AirportsCsvFilePath!);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<AirportRecordMap>();
            var records = csv
                          .GetRecords<AirportRecord>()?
                          .GroupBy(x => x.IATACode)
                          .Where(x=>!string.IsNullOrEmpty(x.Key))
                          .ToDictionary(x => x.Key!, x => x.First()) ?? new Dictionary<string, AirportRecord>();

            return new ReadOnlyDictionary<string, AirportRecord>(records);
        }
    }
}