using System;
using VehicleManagementSystemBusiness.Concrete.Enum;
using VehicleManagementSystemBusiness.Infrastructure.Base;

namespace VehicleManagementSystemBusiness.Concrete.Utils
{
    public class ConnectionProcess : SingletonBase<ConnectionProcess>
    {
        ConnectionProcess()
        {
            InitializeConnection();
        }

        private void InitializeConnection()
        {
            SetConnection();
        }

        private void SetConnection()
        {
            var processLevelConnectionType = Environment.GetEnvironmentVariable("VEHICLEMANAGEMENT_CONNECTIONTYPE", EnvironmentVariableTarget.Process);
            var userLevelConnectionType = Environment.GetEnvironmentVariable("VEHICLEMANAGEMENT_CONNECTIONTYPE", EnvironmentVariableTarget.User);
            var connectionUrl = string.IsNullOrEmpty(processLevelConnectionType) ? userLevelConnectionType : processLevelConnectionType;
            ConnectionType = int.TryParse(connectionUrl, out int connectionTypeId) ? (ConnectionType)connectionTypeId : ConnectionType.Json;
        }

        public ConnectionType ConnectionType { get; private set; }
    }
}
