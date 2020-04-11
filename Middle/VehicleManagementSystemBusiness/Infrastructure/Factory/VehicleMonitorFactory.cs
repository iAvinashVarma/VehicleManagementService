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
        public static IVehicleMonitorRepository<VehicleMonitor> Repository
        {
            get
            {
                IVehicleMonitorRepository<VehicleMonitor> vehicleMonitorRepository;
                var connectionType = ConnectionProcess.Instance.ConnectionType;
                switch (connectionType)
                {
                    case ConnectionType.MongoDb:
                        vehicleMonitorRepository = new MongoRepo.VehicleMonitorRepository();
                        break;
                    case ConnectionType.Json:
                        vehicleMonitorRepository = new JsonRepo.VehicleMonitorRepository();
                        break;
                    default:
                        vehicleMonitorRepository = new JsonRepo.VehicleMonitorRepository();
                        break;
                }
                return vehicleMonitorRepository;
            }
        }
    }
}
