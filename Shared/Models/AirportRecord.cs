using CsvHelper.Configuration;

namespace AirportDistance.Shared.Models {
    public class AirportRecord {
        public int RowId { get; set; }
        public string? Airport { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? IATACode { get; set; }
        public string? ICAOCode { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double AltitudeFt { get; set; }
        public double TimeZone { get; set; }
        public string? DST { get; set; }
        public string? TZ { get; set; }
    }

    public sealed class AirportRecordMap : ClassMap<AirportRecord> {
        public AirportRecordMap() {
            //rowID,Airport,City,Country,IATACode,ICAOCode,Latitude,Longitude,AltitudeFt,TimeZone,DST,TZ
            
            Map(p => p.RowId).Name("rowID");
            Map(p => p.Airport).Name(nameof(AirportRecord.Airport));
            Map(p => p.City).Name(nameof(AirportRecord.City));
            Map(p => p.Country).Name(nameof(AirportRecord.Country));
            Map(p => p.IATACode).Name(nameof(AirportRecord.IATACode));
            Map(p => p.ICAOCode).Name(nameof(AirportRecord.ICAOCode));
            Map(p => p.Latitude).Name(nameof(AirportRecord.Latitude));
            Map(p => p.Longitude).Name(nameof(AirportRecord.Longitude));
            Map(p => p.AltitudeFt).Name(nameof(AirportRecord.AltitudeFt));
            Map(p => p.TimeZone).Name(nameof(AirportRecord.TimeZone));
            Map(p => p.DST).Name(nameof(AirportRecord.DST));
            Map(p => p.TZ).Name(nameof(AirportRecord.TZ));
            
        }
    }
}