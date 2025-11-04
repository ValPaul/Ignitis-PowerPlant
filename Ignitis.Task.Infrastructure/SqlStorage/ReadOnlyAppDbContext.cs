using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ignitis.Domain.PowerPlant;

namespace Ignitis.Infrastructure.SqlStorage
{
    public class ReadOnlyAppDbContext : BaseAppDbContext
    {
        public ReadOnlyAppDbContext(DbContextOptions<ReadOnlyAppDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
        }
       
        public DbSet<PowerPlant> PowerPlants => Set<PowerPlant>();

    }
}
