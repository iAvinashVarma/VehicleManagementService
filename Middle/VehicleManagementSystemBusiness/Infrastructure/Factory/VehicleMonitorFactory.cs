using VehicleManagementSystemBusiness.Concrete.Enum;
using VehicleManagementSystemBusiness.Concrete.Utils;
using VehicleManagementSystemBusiness.Infrastructure.Interface;
using VehicleManagementSystemBusiness.Model;
using JsonRepo = VehicleManagementSystemBusiness.Infrastructure.Repository.Json;
using MongoRepo = VehicleManagementSystemBusiness.Infrastructure.Repository.Mongo;

namespace VehicleManagementSystemBusiness.Infrastructure.Factory
{
    public static class VehicleMonitorFactory
    {
        static VehicleMonitorFactory()
        {
            SetVehicleMonitorRepository();
        }

        private static void SetVehicleMonitorRepository()
        {
            var connectionType = ConnectionProcess.Instance.ConnectionType;
            switch (connectionType)
            {
                case ConnectionType.MongoDb:
                    Repository = new MongoRepo.VehicleMonitorRepository();
                    break;
                case ConnectionType.Json:
                    Repository = new JsonRepo.VehicleMonitorRepository();
                    break;
                default:
                    Repository = new JsonRepo.VehicleMonitorRepository();
                    break;
            }
        }

        public static IVehicleMonitorRepository<VehicleMonitor> Repository { get; private set; }
    }
}
