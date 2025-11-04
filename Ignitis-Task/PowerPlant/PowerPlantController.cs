using Ignitis.Application.Dto.PowerPlants;
using Ignitis.Application.Dtos.PowerPlants;
using Ignitis.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ignitis_Task.PowerPlant
{
    [ApiController]
    [Route("api/power-plant")]
    public class PowerPlantController : ControllerBase
    {
        private readonly IPowerPlantService _svc;
        public PowerPlantController(IPowerPlantService svc) => _svc = svc;

        [HttpPost]
        [ProducesResponseType(typeof(PowerPlantResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] PowerPlantCreateRequest req, CancellationToken ct)
        {
            var id = await _svc.CreateAsync(req, ct);

            var createdPowerPlant = await _svc.GetByIdAsync(id, ct);

            return CreatedAtAction(nameof(GetById), new { id }, createdPowerPlant);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
            => (await _svc.GetByIdAsync(id, ct)) is { } dto ? Ok(dto) : NotFound();

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string? owner, [FromQuery] decimal? minPower,
                                                [FromQuery] int page = 1, [FromQuery] int size = 20,
                                                CancellationToken ct = default)
        {
            var (items, total) = await _svc.SearchAsync(owner, minPower, page, size, ct);
            return Ok(new { page, size, total, items });
        }
    }
}
