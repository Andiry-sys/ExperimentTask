using ExperimentTask.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExperimentTask.DAL.ConfigurateEntity
{
    public class ConfigurateDevice : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Devices").HasKey(s=>s.Id);
            builder.Property(s => s.DeviceToken);
            builder.HasOne(s => s.Experiment).WithMany(s => s.Devices).HasForeignKey(s => s.ExperimentId);
            
        }
    }
}
