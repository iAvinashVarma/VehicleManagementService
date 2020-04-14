using VehicleManagementSystemBusiness.Concrete.Enum;
using VehicleManagementSystemBusiness.Concrete.Utils;
using VehicleManagementSystemBusiness.Infrastructure.Interface;
using VehicleManagementSystemBusiness.Model;
using JsonRepo = VehicleManagementSystemBusiness.Infrastructure.Repository.Json;
using MongoRepo = VehicleManagementSystemBusiness.Infrastructure.Repository.Mongo;

namespace VehicleManagementSystemBusiness.Infrastructure.Factory
{
    public static class VehicleFactory
    {
        static VehicleFactory()
        {
            SetVehicleFactory();
        }

        private static void SetVehicleFactory()
        {
            var connectionType = ConnectionProcess.Instance.ConnectionType;
            switch (connectionType)
            {
                case ConnectionType.MongoDb:
                    Repository = new MongoRepo.VehicleRepository();
                    break;
                case ConnectionType.Json:
                    Repository = new JsonRepo.VehicleRepository();
                    break;
                default:
                    Repository = new JsonRepo.VehicleRepository();
                    break;
            }
        }

        public static IVehicleRepository<Vehicle> Repository { get; private set; }
    }
}
