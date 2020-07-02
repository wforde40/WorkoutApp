using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UiChallengeWorkoutApp.MobileAppService.Models;

namespace UiChallengeWorkoutApp.MobileAppService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {

        private readonly IWorkoutRepository _workoutRepository;

        public WorkoutController(IWorkoutRepository workoutRepository) =>
            (_workoutRepository) = (workoutRepository);

        // GET: api/Workout
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Workout>> Get()
        {
            return _workoutRepository.GetAll().ToList();
        }

        // GET: api/Workout/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Workout> Get(int id)
        {
            var workout = _workoutRepository.Get(id);

            if (workout is null) { return new NotFoundResult(); }

            return workout;
        }

        [HttpGet("random", Name = "GetRandom")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Workout> GetRandom([FromQuery]string category, [FromQuery] string type)
        {
            try
            {
                var workout = _workoutRepository.GetRandom(category, type);
                if (workout is null) { return NotFound(); }
                return workout;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }


            return null;
        }

        [HttpGet("Categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<WorkoutCategory>> GetCategories()
        {
            var categories = _workoutRepository.GetCategories();
            return categories.ToList();

        }
        [HttpGet("Types")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<WorkoutType>> GetTypes()
        {
            var types = _workoutRepository.GetTypes();
            return types.ToList();
        }

        [HttpGet("Completed/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<CompletedWorkout>> GetCompletedWorkouts(int id)
        {
            //var startDate = DateTime.Now.Date.AddDays(-numDays);
            //var endDate = DateTime.Now.Date.Add(new TimeSpan(23, 59, 59));

            var startDate = DateTime.Now.DayOfWeek switch
            {
                DayOfWeek.Friday => DateTime.Now.Date.AddDays(-5),
                DayOfWeek.Monday => DateTime.Now.Date.AddDays(-1),
                DayOfWeek.Saturday => DateTime.Now.Date.AddDays(-6),
                DayOfWeek.Sunday => DateTime.Now.Date,
                DayOfWeek.Thursday => DateTime.Now.Date.AddDays(-4),
                DayOfWeek.Tuesday => DateTime.Now.Date.AddDays(-2),
                DayOfWeek.Wednesday => DateTime.Now.Date.AddDays(-3),
                _ => DateTime.Now.Date,
            };

            var endDate = startDate.AddDays(7);


            var workouts = _workoutRepository.GetCompletedWorkouts(id, startDate, endDate);

            if (workouts is null) { return NotFound(); }

            return workouts.ToList();
        }

        [HttpPost("Completed/{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CompletedWorkout> CompleteWorkout([FromBody] CompletedWorkout value)
        {
            _workoutRepository.AddCompletedWorkout(value);
            return CreatedAtAction(nameof(CompleteWorkout), new { value.Id }, value);
        }


        // POST: api/Workout
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Workout> Post([FromBody] Workout value)
        {
            _workoutRepository.Add(value);
            return CreatedAtAction(nameof(Post), new { value.Id }, value);
        }

        // PUT: api/Workout/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public ActionResult Put([FromBody] Workout value) 
        {
            try
            {
                _workoutRepository.Update(value);
            }
            catch
            {
                return BadRequest("Error when updating workout");
            }

            return NoContent();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Delete(int id)
        {
            var workout = _workoutRepository.Remove(id);

            if (workout is null) { return NotFound(); }

            return Ok();
        }
    }
}
