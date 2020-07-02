using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UiChallengeWorkoutApp.MobileAppService.Models;

namespace UiChallengeWorkoutApp.MobileAppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private IExerciseRepository ExerciseRepository; 
        
        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            ExerciseRepository = exerciseRepository;
        }

        // GET: api/Exercise
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Exercise>> Get()
        {
            return ExerciseRepository.GetAll().ToList(); 
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Exercise> GetItem(int id)
        {
            Exercise exercise = ExerciseRepository.Get(id);

            if (exercise == null)
                return NotFound();

            return exercise;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Exercise> Create([FromBody]Exercise exercise)
        {
            ExerciseRepository.Add(exercise);
            return CreatedAtAction(nameof(Create), new { exercise.ID }, exercise);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Edit([FromBody] Exercise exercise)
        {
            try
            {
                ExerciseRepository.Update(exercise);
            }
            catch (Exception)
            {
                return BadRequest("Error while creating");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            Exercise exercise = ExerciseRepository.Remove(id);

            if (exercise == null)
                return NotFound();

            return Ok();
        }
    }
}
