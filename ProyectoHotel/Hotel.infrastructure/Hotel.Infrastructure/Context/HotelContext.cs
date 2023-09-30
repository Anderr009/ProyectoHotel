using Hotel.domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Infrastructure.Context
{
     public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) 
         {

         }
        public DbSet<Client> clients { get; set; }
    }
}
