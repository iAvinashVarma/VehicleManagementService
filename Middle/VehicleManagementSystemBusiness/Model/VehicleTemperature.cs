using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace VehicleManagementSystemBusiness.Model
{
    public class VehicleTemperature
    {
        [JsonProperty(PropertyName = "temperatureCelsius")]
        [BsonElement("temperatureCelsius")]
        public double TemperatureCelsius { get; set; }

        [JsonProperty(PropertyName = "temperatureFahrenheit")]
        [BsonElement("temperatureFahrenheit")]
        public double TemperatureFahrenheit => 32 + (double)(TemperatureCelsius / 0.5556);
    }
}
