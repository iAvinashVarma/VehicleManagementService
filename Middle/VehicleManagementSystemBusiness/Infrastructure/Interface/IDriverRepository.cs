using System.Collections.Generic;

namespace VehicleManagementSystemBusiness.Infrastructure.Interface
{
    public interface IDriverRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetEntitiesByName(string name);

        TEntity GetEntityByIdentity(string identity);

        TEntity Patch(TEntity entity);
    }
}
