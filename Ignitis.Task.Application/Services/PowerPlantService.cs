using FluentValidation;
using Ignitis.Application.Abstractions;
using Ignitis.Application.Dto.PowerPlants;
using Ignitis.Application.Dtos.PowerPlants;
using Ignitis.Application.Interfaces;
using Ignitis.Domain.PowerPlant;

namespace Ignitis.Application.Services
{
    public sealed class PowerPlantService : IPowerPlantService
    {
        private readonly IPowerPlantRepository _repo;
        private readonly IDateTimeProvider _timeProvider;
        private readonly IValidator<PowerPlantCreateRequest> _createValidator;

        public PowerPlantService(IPowerPlantRepository repo,
                                 IDateTimeProvider timeProvider, 
                                 IValidator<PowerPlantCreateRequest> createValidator)
        {
            _repo = repo;
            _timeProvider = timeProvider;
            _createValidator = createValidator;
        }

        public async Task<Guid> CreateAsync(PowerPlantCreateRequest request, CancellationToken ct)
        {
            await _createValidator.ValidateAndThrowAsync(request, ct);

            var entity = new PowerPlant(Guid.NewGuid(), request.Owner, request.Power, request.ValidFrom, request.ValidTo, _timeProvider.UtcNow());
            await _repo.AddAsync(entity, ct);
            return entity.Id;
        }

        public async Task<PowerPlantResponse?> GetByIdAsync(Guid id, CancellationToken ct)
            => (await _repo.GetByIdAsync(id, ct))?.ToResponse();

        public async Task<(IReadOnlyList<PowerPlantResponse> Items, int Total)> SearchAsync(
            string? owner, decimal? minPower, int page, int size, CancellationToken ct)
        {
            var (entities, total) = await _repo.SearchAsync(owner, minPower, page, size, ct);
            var responses = entities.Select(x => x.ToResponse()).ToList();
            return (responses, total);
        }
    }
}
