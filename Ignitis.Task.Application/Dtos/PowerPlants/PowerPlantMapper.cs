using Ignitis.Application.Dto.PowerPlants;
using Ignitis.Domain.PowerPlant;

namespace Ignitis.Application.Dtos.PowerPlants
{
    public static class PowerPlantMapper
    {
        public static PowerPlantResponse ToResponse(this PowerPlant e) => new()
        {
            Id = e.Id,
            Owner = e.Owner,
            Power = e.Power,
            ValidFrom = e.ValidFrom,
            ValidTo = e.ValidTo,
            Created = e.Created,
            Modified = e.Modified
        };
    }
}
