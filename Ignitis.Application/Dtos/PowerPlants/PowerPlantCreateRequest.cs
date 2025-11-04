using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignitis.Application.Dtos.PowerPlants
{
    public sealed class PowerPlantCreateRequest
    {
        public required string Owner { get; set; }
        public decimal Power { get; set; }
        public DateTimeOffset ValidFrom { get; set; }
        public DateTimeOffset? ValidTo { get; set; }
    }
}
