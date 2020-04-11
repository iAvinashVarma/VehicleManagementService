using System;
using System.Collections.Generic;
using System.Linq;
using VehicleManagementSystemBusiness.Infrastructure.Interface;
using VehicleManagementSystemBusiness.Infrastructure.Repository.Base;
using VehicleManagementSystemBusiness.Model;

namespace VehicleManagementSystemBusiness.Infrastructure.Repository.Json
{
    public class VehicleRepository : JsonRepository<Vehicle>, IVehicleRepository<Vehicle>
    {
        public VehicleRepository() : base(@"Data/Vehicle.json")
        {

        }

        public IEnumerable<Vehicle> GetEntitiesByName(string name)
        {
            return GetAll().Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Vehicle GetEntityByRegistrationNumber(string registrationNumber)
        {
            return GetAll().FirstOrDefault(p => p.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));
        }

        public Vehicle Patch(Vehicle vehicle)
        {
            var person = GetById(vehicle.Id);
            return person;
        }
    }
}
