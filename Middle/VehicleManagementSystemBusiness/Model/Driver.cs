﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using VehicleManagementSystemBusiness.Concrete.Enum;
using VehicleManagementSystemBusiness.Custom;
using VehicleManagementSystemBusiness.Infrastructure.Interface;

namespace VehicleManagementSystemBusiness.Model
{
    public class Driver : IEntity
    {
        [JsonProperty(PropertyName = "_id")]
        [BsonId]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        [BsonElement("name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "age")]
        [BsonElement("age")]
        public byte Age { get; set; }

        [JsonProperty(PropertyName = "phone")]
        [BsonElement("phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "identity")]
        [BsonElement("identity")]
        public string Identity { get; set; }

        [JsonProperty(PropertyName = "gender")]
        [BsonElement("gender")]
        public Gender Gender { get; set; }

        [JsonProperty(PropertyName = "createdDate")]
        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "modifiedDate")]
        [BsonElement("modifiedDate")]
        public DateTime ModifiedDate { get; set; }
    }
}
