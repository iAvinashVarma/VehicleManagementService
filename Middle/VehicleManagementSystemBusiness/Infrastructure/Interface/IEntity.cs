using MongoDB.Bson;
using System;

namespace VehicleManagementSystemBusiness.Infrastructure.Interface
{
    public interface IEntity
    {
        ObjectId Id { get; set; }

        DateTime UpdatedDate { get; set; }

        DateTime ModifiedDate { get; set; }
    }
}
