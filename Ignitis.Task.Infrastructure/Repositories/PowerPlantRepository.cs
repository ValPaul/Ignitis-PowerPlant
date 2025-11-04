using Ignitis.Application.Abstractions;
using Ignitis.Domain.PowerPlant;
using Ignitis.Infrastructure.SqlStorage;
using Microsoft.EntityFrameworkCore;

namespace Ignitis.Infrastructure.Repositories
{
    public class PowerPlantRepository : IPowerPlantRepository
    {
        private readonly AppDbContext _db;
        private readonly ReadOnlyAppDbContext _readOnlyDb;
        public PowerPlantRepository(AppDbContext db, ReadOnlyAppDbContext readOnlyDb)
        {
            _db = db;
            _readOnlyDb = readOnlyDb;
        }

        public async Task AddAsync(PowerPlant e, CancellationToken ct)
        {
            await _db.PowerPlants.AddAsync(e, ct);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<PowerPlant?> GetByIdAsync(Guid id, CancellationToken ct)
            => await _readOnlyDb.PowerPlants.FirstOrDefaultAsync(x => x.Id == id, ct);

        public async Task<(IReadOnlyList<PowerPlant> Items, int Total)> SearchAsync(
        string? owner, decimal? minPower, int page, int size, CancellationToken ct)
        {
            var query = _readOnlyDb.PowerPlants.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(owner))
                query = query.Where(x => x.Owner.ToLower().Contains(owner));

            if (minPower.HasValue)
                query = query.Where(x => x.Power >= minPower.Value);

            var total = await query.CountAsync(ct);

            var items = await query
                .OrderBy(x => x.Owner)
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync(ct);

            return (items, total);
        }

    }
}
