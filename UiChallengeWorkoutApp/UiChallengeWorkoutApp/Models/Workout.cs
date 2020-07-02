using System;
using System.Collections.Generic;
using System.Text;
using UiChallengeWorkoutApp.MobileAppService.Models;

namespace UiChallengeWorkoutApp.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Exercise> Exercises { get; set; }
    }
}
