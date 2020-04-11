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
        public static IVehicleRepository<Vehicle> Repository
        {
            get
            {
                IVehicleRepository<Vehicle> vehicleRepository;
                var connectionType = ConnectionProcess.Instance.ConnectionType;
                switch (connectionType)
                {
                    case ConnectionType.MongoDb:
                        vehicleRepository = new MongoRepo.VehicleRepository();
                        break;
                    case ConnectionType.Json:
                        vehicleRepository = new JsonRepo.VehicleRepository();
                        break;
                    default:
                        vehicleRepository = new JsonRepo.VehicleRepository();
                        break;
                }
                return vehicleRepository;
            }
        }
    }
}
