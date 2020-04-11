using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace VehicleManagementSystemBusiness.Model
{
    public class VehicleLocation
    {
        [JsonProperty(PropertyName = "latitude")]
        [BsonElement("latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        [BsonElement("longitude")]
        public double Longitude { get; set; }
    }
}
