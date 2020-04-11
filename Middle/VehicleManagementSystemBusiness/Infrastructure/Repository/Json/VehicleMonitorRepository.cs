using System.Collections.Generic;
using System.Linq;
using VehicleManagementSystemBusiness.Infrastructure.Factory;
using VehicleManagementSystemBusiness.Infrastructure.Interface;
using VehicleManagementSystemBusiness.Infrastructure.Repository.Base;
using VehicleManagementSystemBusiness.Model;

namespace VehicleManagementSystemBusiness.Infrastructure.Repository.Json
{
    public class VehicleMonitorRepository : JsonRepository<VehicleMonitor>, IVehicleMonitorRepository<VehicleMonitor>
    {
        public VehicleMonitorRepository() : base(@"Data/VehicleMonitor.json")
        {

        }

        public IEnumerable<VehicleMonitor> GetEntitiesByVehicleName(string vehicleName)
        {
            var vehicles = VehicleFactory.Repository.GetEntitiesByName(vehicleName);
            if(vehicles.Any())
            {
                return GetAll().Where(p => vehicles.Select(x => x.Id).Any(v => v.Equals(p)));
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<VehicleMonitor> GetEntitiesByDriverName(string driverName)
        {
            var drivers = DriverFactory.Repository.GetEntitiesByName(driverName);
            if(drivers.Any())
            {
                return GetAll().Where(p => drivers.Select(x => x.Id).Any(d => d.Equals(p)));
            }
            else
            {
                return null;
            }
        }

        public VehicleMonitor Patch(VehicleMonitor vehicleMonitor)
        {
            var person = GetById(vehicleMonitor.Id);
            return person;
        }
    }
}
