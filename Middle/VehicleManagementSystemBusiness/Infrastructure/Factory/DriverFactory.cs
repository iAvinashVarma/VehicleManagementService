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
        static DriverFactory()
        {
            SetDriverFactory();
        }

        private static void SetDriverFactory()
        {
            var connectionType = ConnectionProcess.Instance.ConnectionType;
            switch (connectionType)
            {
                case ConnectionType.MongoDb:
                    Repository = new MongoRepo.DriverRepository();
                    break;
                case ConnectionType.Json:
                    Repository = new JsonRepo.DriverRepository();
                    break;
                default:
                    Repository = new JsonRepo.DriverRepository();
                    break;
            }
        }

        public static IDriverRepository<Driver> Repository { get; private set; }
    }
}
