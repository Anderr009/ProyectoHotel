using Hotel.domain.Entities;
using Hotel.infraestructure.Context;
using Hotel.infraestructure.Core;
using Hotel.infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Hotel.infraestructure.Repositories
{
    public class ReceptionRepository : BaseRepository<Reception>, IReceptionRepository
    {
        private readonly HotelContext context;

        public ReceptionRepository(HotelContext context) : base(context) 
        {
            this.context = context;
        }

        public List<Reception> GetReceptionByClient(int clientId)
        {
            return this.context.Receptions.Where(cd => cd.ClientId == clientId
                                              && !cd.Removed).ToList();
        }

        public List<Reception> GetReceptionByRoom(int roomId)
        {
            return this.context.Receptions.Where(cd => cd.RoomId == roomId
                                              && !cd.Removed).ToList();
        }

        public override List<Reception> GetEntities()
        {
            return base.GetEntities().Where(co => !co.Removed).ToList();
        }

        public override void Save(Reception entity)
        {
            context.Receptions.Add(entity);
            context.SaveChanges();

        }

        public override void Update(Reception entity)
        {
            var receptionUpdate = base.GetEntity(entity.ReceptionId);
            receptionUpdate.ClientId = entity.ClientId;
            receptionUpdate.RoomId = entity.RoomId;
            receptionUpdate.EntryDate = entity.EntryDate;
            receptionUpdate.DepartureDate = entity.DepartureDate;
            receptionUpdate.ConfirmationDepartureDate = entity.ConfirmationDepartureDate;
            receptionUpdate.StartingPrice = entity.StartingPrice;
            receptionUpdate.Advancement = entity.Advancement;
            receptionUpdate.RemainingPrice = entity.RemainingPrice;
            receptionUpdate.TotalPaid = entity.TotalPaid;
            receptionUpdate.CostPenalty = entity.CostPenalty;
            receptionUpdate.Observation = entity.Observation;
            receptionUpdate.State = entity.State;
            receptionUpdate.RegistrationDate = entity.RegistrationDate;
            receptionUpdate.CreationUserId = entity.CreationUserId;

            context.Receptions.Update(receptionUpdate);
            context.SaveChanges();
        }
        public override void Remove(Reception entity)
        {
            var ReceptionToRemove = base.GetEntity(entity.ReceptionId);

            ReceptionToRemove.ReceptionId = entity.ReceptionId;
            ReceptionToRemove.Removed = entity.Removed;
            ReceptionToRemove.DateDeleted = entity.DateDeleted;
            ReceptionToRemove.DeletedUserId = entity.DeletedUserId;

            this.context.Receptions.Update(ReceptionToRemove);
            this.context.SaveChanges();

        }
    }
}
