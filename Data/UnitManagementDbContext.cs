using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using UnitApi9K.Models;

namespace UnitApi9K.Data
{
    public class UnitManagementDbContext : DbContext
    {
        public UnitManagementDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Handler> Handlers => Set<Handler>();
        public DbSet<Dog> Dogs => Set<Dog>();
        public DbSet<TrainingSession> TrainingSessions => Set<TrainingSession>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Handler>()
                .HasOne(d => d.Dog)
                .WithOne(d => d.Handler)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Dog>()
                .HasMany(t => t.TrainingSession)
                .WithOne(t => t.Dog);
            modelBuilder.Entity<TrainingSession>();
        }
     }
}
