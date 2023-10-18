using Hotel.domain.Entities;
using Hotel.domain.Repository;
using Hotel.infraestructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.infraestructure.Core
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly HotelContext context;
        private DbSet<TEntity> entities;
        public BaseRepository(HotelContext context) 
        {
            this.context = context;
            this.entities = this.context.Set<TEntity>();
        }
        public bool Exists(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Any(filter);
        }

        public List<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return this.entities.Where(filter).ToList();
        }

        public List<TEntity> GetEntities()
        {
            return entities.ToList();
        }

        public TEntity GetEntity(int Id)
        {
            return this.entities.Find(Id);
        }

        public void Remove(TEntity entity)
        {
            this.entities.Remove(entity);
        }

        public void Save(TEntity entity)
        {
            this.entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            this.entities.Update(entity);
        }
    }
}
