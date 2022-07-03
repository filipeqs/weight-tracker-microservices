using System.Net;
using Microsoft.AspNetCore.Mvc;
using MuscleGroups.API.DTOs;
using MuscleGroups.API.Entities;
using MuscleGroups.API.Repositories;

namespace MuscleGroups.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MuscleGroupController : ControllerBase
    {
        private IMuscleGroupRepository _repository;
        private readonly ILogger<MuscleGroupController> _logger;

        public MuscleGroupController(IMuscleGroupRepository repository, ILogger<MuscleGroupController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MuscleGroup>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MuscleGroup>>> GetMuscleGroups()
        {
            var muscleGroups = await _repository.GetAllAsync();

            return Ok(muscleGroups);
        }

        [HttpGet("{id}", Name = "GetMuscleGroup")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(MuscleGroup), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MuscleGroup>> GetMuscleGroup(int id)
        {
            var muscleGroup = await _repository.GetByIdAsync(id);

            if (muscleGroup == null)
            {
                _logger.LogError($"Muslce Groups with id: {id}, not found.");
                return NotFound();
            }

            return Ok(muscleGroup);
        }

        [HttpGet("name/{name}", Name = "GetMuscleGroupsByName")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<MuscleGroup>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<MuscleGroup>>> GetMuscleGroupsByName(string name)
        {
            var muscleGroups = await _repository.GetByNameAsync(name);

            if (muscleGroups == null)
            {
                _logger.LogError($"Muslce Groups that contains {name}, not found.");
                return NotFound();
            }

            return Ok(muscleGroups);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(MuscleGroup), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MuscleGroup>> CreateMuscleGroup([FromBody] MuscleGroupCreateDto muscleGroupCreateDto)
        {
            var muscleGroup = new MuscleGroup { Name = muscleGroupCreateDto.Name };

            await _repository.AddAsync(muscleGroup);
            await _repository.SaveChangesAsync();

            return CreatedAtRoute("GetMuscleGroup", new { id = muscleGroup.Id }, muscleGroup);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(MuscleGroup), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<MuscleGroup>> UpdateMuscleGroup([FromBody] MuscleGroupUpdateDto muscleGroupUpdateDto)
        {
            var muscleGroup = await _repository.GetByIdAsync(muscleGroupUpdateDto.Id);

            if (muscleGroup == null)
            {
                _logger.LogError($"Muslce Groups with id: {muscleGroupUpdateDto.Id}, not found.");
                return NotFound();
            }

            muscleGroup.Name = muscleGroupUpdateDto.Name;

            _repository.Update(muscleGroup);
            await _repository.SaveChangesAsync();

            return Ok(muscleGroup);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteMuscleGroup(int id)
        {
            var muscleGroup = await _repository.GetByIdAsync(id);

            if (muscleGroup == null)
            {
                _logger.LogError($"Muslce Groups with id: {id}, not found.");
                return NotFound();
            }

            _repository.Delete(muscleGroup);
            await _repository.SaveChangesAsync();

            return Ok();
        }
    }
}
