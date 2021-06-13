namespace AirportDistance.Shared.Models {
    /// <summary>
    /// Application settings
    /// </summary>
    public class ServiceConfiguration {
        /// <summary>
        /// Path to CSV file with airports
        /// </summary>
        public string? AirportsCsvFilePath { get; set; }
    }
}