using System.Collections.Generic;
using System.Linq;
using VehicleManagementSystemBusiness.Infrastructure.Factory;
using VehicleManagementSystemBusiness.Infrastructure.Interface;
using VehicleManagementSystemBusiness.Infrastructure.Repository.Base;
using VehicleManagementSystemBusiness.Model;

namespace VehicleManagementSystemBusiness.Infrastructure.Repository.Json
{
    public class DriverMessengerRepository : JsonRepository<DriverMessenger>, IDriverMessengerRepository<DriverMessenger>
    {
        public DriverMessengerRepository() : base(@"Data/DriverMessenger.json")
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

        public IEnumerable<DriverMessenger> GetEntitiesByDriverName(string driverName)
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
            var person = GetById(DriverMessenger.Id);
            return person;
        }
    }
}
