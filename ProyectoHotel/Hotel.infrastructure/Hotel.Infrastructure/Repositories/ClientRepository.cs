using Hotel.domain.Entities;
using Hotel.infraestructure.Core;
using Hotel.Infrastructure.Context;
using Hotel.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Infrastructure.Repositories
{
    public  class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly HotelContext context;
        public ClientRepository(HotelContext context) : base(context)
        {
            this.context = context;
        }
        List<Client> IClientRepository.GetReceptionByClient(int ClientId)
        {
            return this.context.Clients.Local.Where(cd => cd.ClientId == ClientId 
                                                          && !cd.Removed).ToList();

        }

        public override List<Client> GetEntities()     
        {
            return base.GetEntities().Where(co => !co.Removed).ToList();
        }

        public override void Save(Client entity)
        {
            context.Clients.Add(entity);
            context.SaveChanges();

        }
        public override void Update(Client entity)
        {
            var ClientUpdate = base.GetEntity(entity.ClientId);
            ClientUpdate.ClientId = entity.ClientId;
            ClientUpdate.FullName = entity.FullName;
            ClientUpdate.DocumentType = entity.DocumentType;
            ClientUpdate.Document = entity.Document;
            ClientUpdate.State = entity.State;
            ClientUpdate.RegistrationDate = entity.RegistrationDate;
            ClientUpdate.CreationUserId = entity.CreationUserId;

            ClientUpdate.Removed = entity.Removed;
            ClientUpdate.DateDeleted = entity.DateDeleted;
            ClientUpdate.Mail = entity.Mail;
            ClientUpdate.ModUserId = entity.ModUserId;
            ClientUpdate.ModDate = entity.ModDate;

            context.Update(ClientUpdate);
            context.SaveChanges();
        }

        public List<Client> GetReceptionByClient(int clientId)
        {
            throw new NotImplementedException();
        }
    }
    
}
