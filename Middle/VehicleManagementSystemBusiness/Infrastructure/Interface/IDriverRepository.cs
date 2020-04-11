using System.Collections.Generic;

namespace VehicleManagementSystemBusiness.Infrastructure.Interface
{
    public interface IDriverRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetEntitiesByName(string name);

        IEnumerable<TEntity> GetEntitiesByIdentity(string identity);

        TEntity Patch(TEntity entity);
    }
}
