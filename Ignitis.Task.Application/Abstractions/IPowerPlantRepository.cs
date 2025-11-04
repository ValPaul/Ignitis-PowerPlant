using Ignitis.Domain.PowerPlant;

namespace Ignitis.Application.Abstractions
{
    public interface IPowerPlantRepository
    {
        Task AddAsync(PowerPlant entity, CancellationToken ct);
        Task<PowerPlant?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<(IReadOnlyList<PowerPlant> Items, int Total)> SearchAsync(
            string? owner, decimal? minPower, int page, int size, CancellationToken ct);
    }
}
