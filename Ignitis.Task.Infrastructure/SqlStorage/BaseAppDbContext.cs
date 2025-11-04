using Ignitis.Domain.PowerPlant;
using Ignitis.Infrastructure.SqlStorage.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignitis.Infrastructure.SqlStorage
{
    public abstract class BaseAppDbContext : DbContext
    {
        protected BaseAppDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseAppDbContext).Assembly);
        }
    }
}
