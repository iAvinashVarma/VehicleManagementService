using System.Collections.Generic;

namespace VehicleManagementSystemBusiness.Infrastructure.Interface
{
    public interface IDriverMessengerRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetEntitiesByVehicleName(string vehicleName);

        IEnumerable<TEntity> GetEntitiesByDriverName(string driverName);

        TEntity Patch(TEntity entity);
    }
}
