using Hotel.domain.Entities;
using Hotel.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Infrastructure.Models
{
    public class ClientRepository : IClientRepository
    {
        public List<Client> GetEntities()
        {
            throw new NotImplementedException();
        }

        public Client GetEntity(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Client entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Client entity)
        {
            throw new NotImplementedException();
        }
    }
}
