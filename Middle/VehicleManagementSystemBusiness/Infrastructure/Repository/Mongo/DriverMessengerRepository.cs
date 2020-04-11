using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using VehicleManagementSystemBusiness.Concrete.Utils;
using VehicleManagementSystemBusiness.Infrastructure.Factory;
using VehicleManagementSystemBusiness.Infrastructure.Interface;
using VehicleManagementSystemBusiness.Infrastructure.Repository.Base;
using VehicleManagementSystemBusiness.Model;

namespace VehicleManagementSystemBusiness.Infrastructure.Repository.Mongo
{
    public class DriverMessengerRepository : MongoRepository<DriverMessenger>, IDriverMessengerRepository<DriverMessenger>
    {
        public DriverMessengerRepository() : base(DatabaseCredential.Instance.ConnectionString, DatabaseCredential.DatabaseName, DatabaseCredential.DriverMessengerCollectionName)
        {

        }

        public IEnumerable<DriverMessenger> GetEntitiesByVehicleName(string vehicleName)
        {
            var vehicles = VehicleFactory.Repository.GetEntitiesByName(vehicleName);
            if (vehicles.Any())
            {
                return GetAll().Where(p => vehicles.Select(x => x.Id).Any(v => v.Equals(p)));
            }
            else
            {
                return null;
            }
        }

        public virtual IEnumerable<DriverMessenger> GetEntitiesByDriverName(string driverName)
        {
            var drivers = DriverFactory.Repository.GetEntitiesByName(driverName);
            if (drivers.Any())
            {
                return GetAll().Where(p => drivers.Select(x => x.Id).Any(d => d.Equals(p)));
            }
            else
            {
                return null;
            }
        }

        public DriverMessenger Patch(DriverMessenger DriverMessenger)
        {
            var filter = Builders<DriverMessenger>.Filter.Eq(u => u.Id, DriverMessenger.Id);
            var result = _mongoCollection.Find(filter).SingleOrDefault();
            _mongoCollection.InsertOne(result);
            return result;
        }
    }
}
