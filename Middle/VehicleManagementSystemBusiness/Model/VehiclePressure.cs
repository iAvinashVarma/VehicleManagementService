using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace VehicleManagementSystemBusiness.Model
{
    public class VehiclePressure
    {
        [JsonProperty(PropertyName = "pressurePsi")]
        [BsonElement("pressurePsi")]
        public double PressurePsi { get; set; }

        [JsonProperty(PropertyName = "pressurePascal")]
        [BsonElement("pressurePascal")]
        public double PressurePascal => 6894.76 * PressurePsi;
    }
}
