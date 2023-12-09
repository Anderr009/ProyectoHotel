using Hotel.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Infraestructure.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}
