using Hotel.domain.Entities;
using Hotel.domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.infraestructure.Interfaces
{
    public interface IReceptionRepository : IBaseRepository<Reception>
    {
        List<Reception> GetReceptionByClient(int clientId);

        List<Reception> GetReceptionByRoom(int clientId);
    }
}
