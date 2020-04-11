using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using VehicleManagementSystemBusiness.Concrete.Utils;
using VehicleManagementSystemBusiness.Infrastructure.Interface;
using VehicleManagementSystemBusiness.Infrastructure.Repository.Base;
using VehicleManagementSystemBusiness.Model;

namespace VehicleManagementSystemBusiness.Infrastructure.Repository.Mongo
{
    public class VehicleRepository : MongoRepository<Vehicle>, IVehicleRepository<Vehicle>
    {
        public VehicleRepository() : base(DatabaseCredential.Instance.ConnectionString, DatabaseCredential.DatabaseName, DatabaseCredential.VehicleCollectionName)
        {

        }

        public IEnumerable<Vehicle> GetEntitiesByName(string name)
        {
            var filter = Builders<Vehicle>.Filter.Eq(u => u.Name, name);
            var result = _mongoCollection.Find(filter).ToList();
            return result;
        }

        public Vehicle Patch(Vehicle patch)
        {
            var filter = Builders<Vehicle>.Filter.Eq(u => u.Id, patch.Id);
            var result = _mongoCollection.Find(filter).SingleOrDefault();
            _mongoCollection.InsertOne(result);
            return result;
        }
    }
}
