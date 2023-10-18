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
    }
}
