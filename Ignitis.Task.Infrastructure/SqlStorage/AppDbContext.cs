using Ignitis.Domain.PowerPlant;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignitis.Infrastructure.SqlStorage
{
    public class AppDbContext : BaseAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PowerPlant> PowerPlants => Set<PowerPlant>();

    }
}
