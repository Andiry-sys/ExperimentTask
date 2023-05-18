using ExperimentTask.DAL.ConfigurateEntity;
using ExperimentTask.Model;
using Microsoft.EntityFrameworkCore;

namespace ExperimentTask.Context
{
    public class ExperimentContext :DbContext
    {
        public ExperimentContext(DbContextOptions<ExperimentContext> options):base(options)
        {

        }

        public DbSet<Experiment>? Experiments { get; set; }
        public DbSet<Device>? Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new ConfigurateExpirement());
           modelBuilder.ApplyConfiguration(new ConfigurateDevice());
            
        }
    }
}
