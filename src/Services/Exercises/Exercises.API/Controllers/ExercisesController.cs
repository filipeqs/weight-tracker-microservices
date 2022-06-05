using Exercises.API.Entities;
using Exercises.API.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Exercises.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly ILogger<ExercisesController> _logger;

        public ExercisesController(IExerciseRepository exerciseRepository, ILogger<ExercisesController> logger)
        {
            _exerciseRepository = exerciseRepository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Exercise>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
        {
            var exercises = await _exerciseRepository.GetExercises();
            return Ok(exercises);
        }

        [HttpGet]
        [Route("{id}", Name = "GetExercise")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Exercise), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Exercise>> GetExercise(string id)
        {
            var exercise = await _exerciseRepository.GetExerciseById(id);

            if (exercise == null)
            {
                _logger.LogError($"Exercise with id: {id}, not found.");
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpGet]
        [Route("name/{name}", Name = "GetExerciseByName")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Exercise>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExerciseByName(string name)
        {
            var exercise = await _exerciseRepository.GetExerciseByName(name);

            if (exercise == null)
            {
                _logger.LogError($"Exercise that container {name}, not found.");
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Exercise), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Exercise>> CreateExercise([FromBody]Exercise exercise)
        {
            await _exerciseRepository.CreateExercise(exercise);

            return CreatedAtRoute("GetExercise", new { id = exercise.Id }, exercise);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Exercise), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Exercise>> UpdateExercise([FromBody] Exercise exercise)
        {
            var updated = await _exerciseRepository.UpdateExercise(exercise);
            if (!updated)
            {
                _logger.LogError($"Failed to updated exercise with id: {exercise.Id}");
                return BadRequest("Failed to updated exercise");
            }

            return Ok(exercise);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteExerciseById(string id)
        {
            var deleted = await _exerciseRepository.DeleteExercise(id);
            if (!deleted)
            {
                _logger.LogError($"Failed to delete exercise with id: {id}");
                return BadRequest("Failed to delete exercise");
            }

            return Ok();
        }
    }
}
