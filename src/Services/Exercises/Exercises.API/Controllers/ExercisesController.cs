using AutoMapper;
using Exercises.API.DTOs.ExerciseDTOs;
using Exercises.API.DTOs.MuscleGroupDTOs;
using Exercises.API.Entities;
using Exercises.API.Repositories;
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
        private readonly IMapper _mapper;

        public ExercisesController(IExerciseRepository exerciseRepository, ILogger<ExercisesController> logger, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExerciseDetailsDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ExerciseDetailsDto>>> GetExercises()
        {
            var exercises = await _exerciseRepository.GetExercises();
            var exercisesDto = _mapper.Map<IEnumerable<ExerciseDetailsDto>>(exercises);

            return Ok(exercisesDto);
        }

        [HttpGet]
        [Route("{id}", Name = "GetExercise")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ExerciseDetailsDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ExerciseDetailsDto>> GetExercise(int id)
        {
            var exercise = await _exerciseRepository.GetExerciseById(id);

            if (exercise == null)
            {
                _logger.LogError($"Exercise with id: {id}, not found.");
                return NotFound();
            }

            var exerciseDto = _mapper.Map<ExerciseDetailsDto>(exercise);

            return Ok(exerciseDto);
        }

        [HttpGet]
        [Route("name/{name}", Name = "GetExerciseByName")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<ExerciseDetailsDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ExerciseDetailsDto>>> GetExerciseByName(string name)
        {
            var exercise = await _exerciseRepository.GetExerciseByName(name);

            if (exercise == null)
            {
                _logger.LogError($"Exercise that container {name}, not found.");
                return NotFound();
            }

            var exerciseDto = _mapper.Map<IEnumerable<ExerciseDetailsDto>>(exercise);

            return Ok(exerciseDto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ExerciseDetailsDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ExerciseDetailsDto>> CreateExercise([FromBody] ExerciseCreateDto exerciseCreateDto)
        {
            var exercise = _mapper.Map<Exercise>(exerciseCreateDto);
            await _exerciseRepository.CreateExercise(exercise);

            var exerciseDto = _mapper.Map<ExerciseDetailsDto>(exercise);

            return CreatedAtRoute("GetExercise", new { id = exercise.Id }, exerciseDto);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ExerciseDetailsDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ExerciseDetailsDto>> UpdateExercise([FromBody] ExerciseUpdateDto exerciseUpdateDto)
        {
            var exercise = await _exerciseRepository.GetExerciseById(exerciseUpdateDto.Id);

            if (exercise == null)
            {
                _logger.LogError($"Exercise with id: {exerciseUpdateDto.Id}, not found.");
                return NotFound();
            }

            var updated = await _exerciseRepository.UpdateExercise(exercise);
            if (!updated)
            {
                _logger.LogError($"Failed to updated exercise with id: {exercise.Id}");
                return BadRequest("Failed to updated exercise");
            }

            var exerciseDto = _mapper.Map<ExerciseDetailsDto>(exercise);

            return Ok(exerciseDto);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteExerciseById(int id)
        {
            var deleted = await _exerciseRepository.DeleteExercise(id);
            if (!deleted)
            {
                _logger.LogError($"Failed to delete exercise with id: {id}");
                return BadRequest("Failed to delete exercise");
            }

            return Ok();
        }

        [HttpPost("{id}/muscleGroup")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMuscleGroups(int id, [FromBody] List<MuscleGroupCreateDto> muscleGroupDetailsDto)
        {
            var exercise = _exerciseRepository.GetExerciseById(id);
            if (exercise == null)
            {
                _logger.LogError($"Exercise with id: {id}, not found.");
                return NotFound();
            }

            var muscleGroups = _mapper.Map<List<MuscleGroup>>(muscleGroupDetailsDto);

            var updated = await _exerciseRepository.UpdateMuscleGroup(id, muscleGroups);
            if (!updated)
            {
                _logger.LogError($"Failed to updated exercise with id: {exercise.Id}");
                return BadRequest("Failed to updated exercise");
            }

            return Ok();
        }
    }
}
