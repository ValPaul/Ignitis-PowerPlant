using FluentValidation;
using Ignitis.Application.Dtos.PowerPlants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignitis.Application.Validations
{
    public sealed class PowerPlantCreateRequestValidator : AbstractValidator<PowerPlantCreateRequest>
    {
        public PowerPlantCreateRequestValidator()
        {
            RuleFor(x => x.Owner)
                .NotEmpty()
                .MaximumLength(128)
                .Must(owner => owner != null && owner.Trim().Contains(' ')).WithMessage("Owner must include both first and last name, separated by a space.");
            RuleFor(x => x.Power)
                .GreaterThan(0)
                .LessThan(200);
            RuleFor(x => x.ValidFrom)
                .LessThan(x => x.ValidTo).When(x => x.ValidTo.HasValue);
            RuleFor(x => x.ValidTo)
                .GreaterThan(x => x.ValidFrom).When(x => x.ValidTo.HasValue);
        }
    }
}
