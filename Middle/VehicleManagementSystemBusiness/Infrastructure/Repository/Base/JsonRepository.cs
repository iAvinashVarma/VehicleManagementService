using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using VehicleManagementSystemBusiness.Concrete.Utils;
using VehicleManagementSystemBusiness.Infrastructure.Interface;

namespace VehicleManagementSystemBusiness.Infrastructure.Repository.Base
{
    public abstract class JsonRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        public JsonRepository(string relativeConnectionString)
        {
            RelativeConnectionString = relativeConnectionString;
            AbsoluteConnectionString = Path.Combine(AssemblyDirectory, relativeConnectionString);
        }

        public virtual string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public string AbsoluteConnectionString { get; set; }
        public string RelativeConnectionString { get; set; }

        public virtual TEntity Add(TEntity entity)
        {
            var entities = GetAll().ToList();
            entity.Id = ObjectId.GenerateNewId();
            entity.ModifiedDate = DateTime.Now;
            entities.Add(entity);
            SaveChanges(entities);
            return entity;
        }

        public virtual void Dispose()
        {
            // Nothing to dispose.
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var entities = FileProcess.Instance.ReadAllText(AbsoluteConnectionString);
            return JsonConvert.DeserializeObject<IEnumerable<TEntity>>(entities);
        }

        public virtual TEntity GetById(ObjectId id)
        {
            return GetAll().FirstOrDefault(p => p.Id == id);
        }

        public virtual bool Remove(ObjectId id)
        {
            try
            {
                var entities = GetAll().ToList();
                var entity = entities.FirstOrDefault(p => p.Id == id);
                if (entity != null)
                {
                    entity.ModifiedDate = DateTime.Now;
                    entities.Remove(entity);
                    SaveChanges(entities);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool Update(TEntity entity)
        {
            try
            {
                var entities = GetAll().ToList();
                var updateEntity = entities.FirstOrDefault(p => p.Id == entity.Id);
                if (updateEntity != null)
                {
                    var createdDate = updateEntity.CreatedDate;
                    var modifiedDate = DateTime.Now;
                    entities.Remove(updateEntity);
                    updateEntity = entity;
                    updateEntity.ModifiedDate = DateTime.Now;
                    updateEntity.CreatedDate = createdDate;
                    entities.Add(updateEntity);
                    SaveChanges(entities);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private KeyValuePair<bool, Exception> SaveChanges(IEnumerable<TEntity> entities)
        {
            bool isSave = false;
            Exception exception = null;
            try
            {
                var orderPeople = entities.OrderBy(p => p.Id);
                var serialize = JsonConvert.SerializeObject(orderPeople, Formatting.Indented);
                FileProcess.Instance.WriteAllText(AbsoluteConnectionString, serialize);
                isSave = true;
            }
            catch (Exception ex)
            {
                ex = exception;
            }
            return new KeyValuePair<bool, Exception>(isSave, exception);
        }
    }
}
