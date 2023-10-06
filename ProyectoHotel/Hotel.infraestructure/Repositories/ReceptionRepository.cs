using Hotel.domain.Entities;
using Hotel.infraestructure.Context;
using Hotel.infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.infraestructure.Repositories
{
    public class ReceptionRepository : IReceptionRepository
    {
        private readonly HotelContext context;

        public ReceptionRepository(HotelContext context)
        {
            this.context = context;
        }
        public bool Exists(Expression<Func<Reception, bool>> filter)
        {
            return this.context.Receptions.Any(filter);
        }

        public List<Reception> GetEntities()
        {
            return this.context.Receptions.Where(st => !st.Deleted).ToList();
        }

        public Reception GetEntity(int Id)
        {
            return this.context.Receptions.Find(Id);
        }

        public void Remove(Reception entity)
        {
            this.context.Receptions.Remove(entity);
        }

        public void Save(Reception entity)
        {
            this.context.Receptions.Add(entity);
        }

        public void Update(Reception entity)
        {
            this.context.Receptions.Update(entity);
        }
    }
}
