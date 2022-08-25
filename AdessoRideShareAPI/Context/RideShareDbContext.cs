using AdessoRideShareAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AdessoRideShareAPI.Context
{
    public class RideShareDbContext : DbContext
    {
        public RideShareDbContext(DbContextOptions<RideShareDbContext> options) : base(options)
        {
        }
        public DbSet<TravelModel> travel { get; set; }
    }
}
