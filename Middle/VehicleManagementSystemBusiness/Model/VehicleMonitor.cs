using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using VehicleManagementSystemBusiness.Custom;
using VehicleManagementSystemBusiness.Infrastructure.Interface;

namespace VehicleManagementSystemBusiness.Model
{
    public class VehicleMonitor : IEntity
    {
        [JsonProperty(PropertyName = "_id")]
        [BsonId]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [JsonProperty(PropertyName = "vehicleId")]
        [BsonElement("vehicleId")]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId VehicleId { get; set; }

        [JsonProperty(PropertyName = "driverId")]
        [BsonElement("driverId")]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId DriverId { get; set; }

        [JsonProperty(PropertyName = "location")]
        [BsonElement("location")]
        public VehicleLocation Location { get; set; }

        //[BsonElement("location")]
        //public GeoJsonPoint<GeoJson2DGeographicCoordinates> Location { get; set; }

        [JsonProperty(PropertyName = "pressure")]
        [BsonElement("pressure")]
        public VehiclePressure Pressure { get; set; }

        [JsonProperty(PropertyName = "temperature")]
        [BsonElement("temperature")]
        public VehicleTemperature Temperature { get; set; }
        
        [JsonProperty(PropertyName = "updatedDate")]
        [BsonElement("updatedDate")]
        public DateTime UpdatedDate { get; set; }

        [JsonProperty(PropertyName = "modifiedDate")]
        [BsonElement("modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
