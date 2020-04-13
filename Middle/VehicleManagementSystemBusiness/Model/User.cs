using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using VehicleManagementSystemBusiness.Custom;
using VehicleManagementSystemBusiness.Infrastructure.Interface;

namespace VehicleManagementSystemBusiness.Model
{
    public class User : IEntity
    {
        [JsonProperty(PropertyName = "_id")]
        [BsonId]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        [BsonElement("name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "password")]
        [BsonElement("password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "createdDate")]
        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "modifiedDate")]
        [BsonElement("modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
