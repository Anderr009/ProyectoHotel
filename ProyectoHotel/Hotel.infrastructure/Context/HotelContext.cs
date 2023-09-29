using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Hotel.domain.Entities;

namespace Hotel.infrastructure.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {

        }

        public DbSet<Reception> Receptions { get; set; }
    }
}
