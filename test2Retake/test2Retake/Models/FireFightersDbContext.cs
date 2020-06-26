using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test2Retake.Configurations;

namespace test2Retake.Models
{
    public class FireFightersDbContext : DbContext
    {
        public FireFightersDbContext()
        {
        }

        public FireFightersDbContext(DbContextOptions<FireFightersDbContext> options)
            : base(options)
        {
        }
        public DbSet<FireFighter> FireFighter { get; set; }
        public DbSet<Action> Action { get; set; }
        public DbSet<FireTruck> FireTruck { get; set; }
        public DbSet<FireTruck_Action> FireTruck_Action { get; set; }
        public DbSet<FireFighter_Action> FireFighter_Action { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FireFightersConfiguration());
            modelBuilder.ApplyConfiguration(new FireFightersConfiguration());
            modelBuilder.ApplyConfiguration(new FireTruckConfiguration());
           


        }
    }
}
