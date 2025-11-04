using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignitis.Application.Dto.PowerPlants
{
    public sealed class PowerPlantResponse
    {
        public Guid Id { get; init; }
        public required string Owner { get; init; }
        public decimal Power { get; init; }
        public DateTimeOffset ValidFrom { get; init; }
        public DateTimeOffset? ValidTo { get; init; }
        public DateTimeOffset Created { get; init; }
        public DateTimeOffset? Modified { get; init; }
    }
}
