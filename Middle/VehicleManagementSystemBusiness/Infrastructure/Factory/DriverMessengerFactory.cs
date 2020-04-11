using VehicleManagementSystemBusiness.Concrete.Enum;
using VehicleManagementSystemBusiness.Concrete.Utils;
using VehicleManagementSystemBusiness.Infrastructure.Interface;
using VehicleManagementSystemBusiness.Model;
using JsonRepo = VehicleManagementSystemBusiness.Infrastructure.Repository.Json;
using MongoRepo = VehicleManagementSystemBusiness.Infrastructure.Repository.Mongo;

namespace VehicleManagementSystemBusiness.Infrastructure.Factory
{
    public static class DriverMessengerFactory
    {
        public static IDriverMessengerRepository<DriverMessenger> Repository
        {
            get
            {
                IDriverMessengerRepository<DriverMessenger> driverRepository;
                var connectionType = ConnectionProcess.Instance.ConnectionType;
                switch (connectionType)
                {
                    case ConnectionType.MongoDb:
                        driverRepository = new MongoRepo.DriverMessengerRepository();
                        break;
                    case ConnectionType.Json:
                        driverRepository = new JsonRepo.DriverMessengerRepository();
                        break;
                    default:
                        driverRepository = new JsonRepo.DriverMessengerRepository();
                        break;
                }
                return driverRepository;
            }
        }
    }
}
