using VehicleManagementSystemBusiness.Concrete.Enum;
using VehicleManagementSystemBusiness.Concrete.Utils;
using VehicleManagementSystemBusiness.Infrastructure.Interface;
using VehicleManagementSystemBusiness.Model;
using JsonRepo = VehicleManagementSystemBusiness.Infrastructure.Repository.Json;
using MongoRepo = VehicleManagementSystemBusiness.Infrastructure.Repository.Mongo;

namespace VehicleManagementSystemBusiness.Infrastructure.Factory
{
    public static class DriverFactory
    {
        public static IDriverRepository<Driver> Repository
        {
            get
            {
                IDriverRepository<Driver> driverRepository;
                var connectionType = ConnectionProcess.Instance.ConnectionType;
                switch (connectionType)
                {
                    case ConnectionType.MongoDb:
                        driverRepository = new MongoRepo.DriverRepository();
                        break;
                    case ConnectionType.Json:
                        driverRepository = new JsonRepo.DriverRepository();
                        break;
                    default:
                        driverRepository = new JsonRepo.DriverRepository();
                        break;
                }
                return driverRepository;
            }
        }
    }
}
