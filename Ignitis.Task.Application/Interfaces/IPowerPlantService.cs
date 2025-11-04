using Ignitis.Application.Dto.PowerPlants;
using Ignitis.Application.Dtos.PowerPlants;

namespace Ignitis.Application.Interfaces
{
    public interface IPowerPlantService
    {
        Task<Guid> CreateAsync(PowerPlantCreateRequest request, CancellationToken ct);
        Task<PowerPlantResponse?> GetByIdAsync(Guid id, CancellationToken ct);
        Task<(IReadOnlyList<PowerPlantResponse> Items, int Total)> SearchAsync(
            string? owner, decimal? minPower, int page, int size, CancellationToken ct);
    }
}
