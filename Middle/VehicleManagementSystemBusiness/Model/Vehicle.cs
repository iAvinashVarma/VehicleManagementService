using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using VehicleManagementSystemBusiness.Custom;
using VehicleManagementSystemBusiness.Infrastructure.Interface;

namespace VehicleManagementSystemBusiness.Model
{
    public class Vehicle : IEntity
    {
        [JsonProperty(PropertyName = "_id")]
        [BsonId]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        [BsonElement("name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "registrationNumber")]
        [BsonElement("registrationNumber")]
        public string RegistrationNumber { get; set; }

        [JsonProperty(PropertyName = "updatedDate")]
        [BsonElement("updatedDate")]
        public DateTime UpdatedDate { get; set; }

        [JsonProperty(PropertyName = "modifiedDate")]
        [BsonElement("modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
