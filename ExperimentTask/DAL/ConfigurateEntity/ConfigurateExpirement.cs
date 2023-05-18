using ExperimentTask.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExperimentTask.DAL.ConfigurateEntity
{
    public class ConfigurateExpirement : IEntityTypeConfiguration<Experiment>
    {
        public void Configure(EntityTypeBuilder<Experiment> builder)
        {
            builder.ToTable("Experiments").HasKey(t => t.Id);
            builder.HasMany(s=>s.Devices).WithOne(s=>s.Experiment).HasForeignKey(s=>s.ExperimentId);
            builder.Property(t => t.Key);
            builder.Property(t => t.Options);
            builder.Property(t => t.Count);
        }
    }
}
