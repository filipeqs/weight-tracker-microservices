using MediatR;
using AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Exercises.Application.DTOs.ExerciseDTOs;
using Exercises.Application.DTOs.MuscleGroupDTOs;
using Exercises.Application.Features.Exercises.Commands.CreateExercise;
using Exercises.Application.Features.Exercises.Commands.DeleteExercise;
using Exercises.Application.Features.Exercises.Commands.UpdateExercise;
using Exercises.Application.Features.Exercises.Queries.GetExerciseById;
using Exercises.Application.Features.Exercises.Queries.GetExercisesList;
using Exercises.Application.Features.Exercises.Queries.GetExerciseByName;
using Exercises.Application.Features.Exercises.Commands.UpdateExerciseMuscleGroup;

namespace Exercises.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly ILogger<ExercisesController> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ExercisesController(ILogger<ExercisesController> logger, IMapper mapper, IMediator mediator)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
        }

        private void LogError(string message)
        {
            _logger.LogError(message);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ExerciseDetailsDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ExerciseDetailsDto>>> GetExercises()
        {
            var query = new GetExercisesListQuery();
            var exercises = await _mediator.Send(query);

            return Ok(exercises);
        }

        [HttpGet]
        [Route("{id}", Name = "GetExercise")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ExerciseDetailsDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ExerciseDetailsDto>> GetExercise(int id)
        {
            var query = new GetExerciseByIdQuery(id);
            var exercise = await _mediator.Send(query);

            if (exercise == null)
            {
                LogError($"Exercise with id: {id}, not found.");
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpGet]
        [Route("name/{name}", Name = "GetExerciseByName")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<ExerciseDetailsDto>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ExerciseDetailsDto>>> GetExerciseByName(string name)
        {
            var query = new GetExerciseByNameQuery(name);
            var exercise = await _mediator.Send(query);

            if (exercise == null)
            {
                LogError($"Exercise that contains {name}, not found.");
                return NotFound();
            }

            return Ok(exercise);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ExerciseDetailsDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ExerciseDetailsDto>> CreateExercise([FromBody] ExerciseCreateDto exerciseCreateDto)
        {
            var command = new CreateExerciseCommand(exerciseCreateDto);
            var exercise = await _mediator.Send(command);

            return CreatedAtRoute("GetExercise", new { id = exercise.Id }, exercise);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ExerciseDetailsDto), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ExerciseDetailsDto>> UpdateExercise([FromBody] ExerciseUpdateDto exerciseUpdateDto)
        {
            var command = new UpdateExerciseCommand(exerciseUpdateDto);
            var exercise = await _mediator.Send(command);

            return Ok(exercise);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteExerciseById(int id)
        {
            var command = new DeleteExerciseCommand(id);
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost("{id}/muscleGroup")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateMuscleGroups(int id, [FromBody] List<MuscleGroupCreateDto> muscleGroupDetailsDto)
        {
            var command = new UpdateExerciseMuscleGroupCommand(id, muscleGroupDetailsDto);
            await _mediator.Send(command);

            return Ok();
        }
    }
}
