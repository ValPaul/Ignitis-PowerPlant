using Ignitis.Domain.PowerPlant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ignitis.Infrastructure.SqlStorage.Configurations
{
    internal class PowerPlantConfiguration : IEntityTypeConfiguration<PowerPlant>
    {
        public void Configure(EntityTypeBuilder<PowerPlant> builder)
        {
            builder.ToTable("PowerPlants");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Owner).IsRequired();
            builder.Property(x => x.Power).IsRequired();
            builder.Property(x => x.ValidFrom).IsRequired();
            builder.Property(x => x.ValidTo);
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.Modified).IsRequired();
        }
    }
}
