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
        static DriverMessengerFactory()
        {
            SetDriverMessengerFactory();
        }

        private static void SetDriverMessengerFactory()
        {
            var connectionType = ConnectionProcess.Instance.ConnectionType;
            switch (connectionType)
            {
                case ConnectionType.MongoDb:
                    Repository = new MongoRepo.DriverMessengerRepository();
                    break;
                case ConnectionType.Json:
                    Repository = new JsonRepo.DriverMessengerRepository();
                    break;
                default:
                    Repository = new JsonRepo.DriverMessengerRepository();
                    break;
            }
        }

        public static IDriverMessengerRepository<DriverMessenger> Repository{ get; private set; }
    }
}
