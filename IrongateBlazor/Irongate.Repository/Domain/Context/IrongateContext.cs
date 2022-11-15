using System.Configuration;
using Irongate.Repository.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Irongate.Repository.Domain.Context
{
	public class IrongateContext : DbContext
    {
        // public IrongateContext(DbContextOptions builder) : base(builder)
        // {
        // }
        
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=10.135.16.30;Database=Irongate;Uid=IRONGATEUSER;Pwd=Q6qfG3vTgYP3MQ9PvZW2WY57eycxGm3YxX99Q6kf4EBfbKzp;");
            Database.EnsureCreated();
        }
        
        public DbSet<Climate> Climates { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<MotionSensor> MotionSensors { get; set; }
        public DbSet <WaterLevel> WaterLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Climate>().HasKey(x => x.ID);
            modelBuilder.Entity<Log>().HasKey(x => x.ID);
            modelBuilder.Entity<MotionSensor>().HasKey(x => x.ID);
            modelBuilder.Entity<WaterLevel>().HasKey(x => x.ID);
        }
    }
}