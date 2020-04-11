using System.Collections.Generic;

namespace VehicleManagementSystemBusiness.Infrastructure.Interface
{
    public interface IVehicleRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetEntitiesByName(string name);

        TEntity Patch(TEntity entity);
    }
}
