﻿using Hotel.domain.Entities;
using Hotel.domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Infrastructure.Interface
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        List<Client> GetReceptionByClient(int clientId);
        List<Client> GetReceptionByRoom(int clientId);
    }
}
