using System;
using System.Collections.Generic;
using System.Linq;
using VehicleManagementSystemBusiness.Infrastructure.Interface;
using VehicleManagementSystemBusiness.Infrastructure.Repository.Base;
using VehicleManagementSystemBusiness.Model;

namespace VehicleManagementSystemBusiness.Infrastructure.Repository.Json
{
    public class DriverRepository : JsonRepository<Driver>, IDriverRepository<Driver>
    {
        public DriverRepository() : base(@"Data/Driver.json")
        {

        }

        public IEnumerable<Driver> GetEntitiesByName(string name)
        {
            return GetAll().Where(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public Driver GetEntityByIdentity(string identity)
        {
            return GetAll().FirstOrDefault(p => p.Identity.Equals(identity, StringComparison.OrdinalIgnoreCase));
        }

        public Driver Patch(Driver driver)
        {
            var person = GetById(driver.Id);
            return person;
        }
    }
}
