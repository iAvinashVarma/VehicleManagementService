using MongoDB.Bson;
using System;

namespace VehicleManagementSystemBusiness.Infrastructure.Interface
{
    public interface IEntity
    {
        ObjectId Id { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime ModifiedDate { get; set; }
    }
}
