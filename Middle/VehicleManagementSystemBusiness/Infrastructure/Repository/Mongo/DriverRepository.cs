using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using VehicleManagementSystemBusiness.Concrete.Utils;
using VehicleManagementSystemBusiness.Infrastructure.Interface;
using VehicleManagementSystemBusiness.Infrastructure.Repository.Base;
using VehicleManagementSystemBusiness.Model;

namespace VehicleManagementSystemBusiness.Infrastructure.Repository.Mongo
{
    public class DriverRepository : MongoRepository<Driver>, IDriverRepository<Driver>
    {
        public DriverRepository() : base(DatabaseCredential.Instance.ConnectionString, DatabaseCredential.DatabaseName, DatabaseCredential.DriverCollectionName)
        {

        }

        public IEnumerable<Driver> GetEntitiesByName(string name)
        {
            var filter = Builders<Driver>.Filter.Eq(u => u.Name, name);
            var result = _mongoCollection.Find(filter).ToList();
            return result;
        }

        public Driver GetEntityByIdentity(string identity)
        {
            var filter = Builders<Driver>.Filter.Eq(u => u.Identity, identity);
            var result = _mongoCollection.Find(filter).FirstOrDefault();
            return result;
        }

        public Driver Patch(Driver driver)
        {
            var filter = Builders<Driver>.Filter.Eq(u => u.Id, driver.Id);
            var result = _mongoCollection.Find(filter).SingleOrDefault();
            _mongoCollection.InsertOne(result);
            return result;
        }
    }
}
