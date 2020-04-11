using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using VehicleManagementSystemBusiness.Custom;
using VehicleManagementSystemBusiness.Infrastructure.Interface;

namespace VehicleManagementSystemBusiness.Model
{
    public class DriverMessenger : IEntity
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

        [JsonProperty(PropertyName = "message")]
        [BsonElement("message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "updatedDate")]
        [BsonElement("updatedDate")]
        public DateTime UpdatedDate { get; set; }

        [JsonProperty(PropertyName = "modifiedDate")]
        [BsonElement("modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
