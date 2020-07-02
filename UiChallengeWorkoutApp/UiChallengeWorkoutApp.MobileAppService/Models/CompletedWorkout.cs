using System;

namespace UiChallengeWorkoutApp.MobileAppService.Models
{
    public class CompletedWorkout
    {
        public int Id { get; set; }
        public int WorkoutID { get; set; }
        public int UserID { get; set; }
        public DateTime DateCompleted { get; set; }

       

    }
}   