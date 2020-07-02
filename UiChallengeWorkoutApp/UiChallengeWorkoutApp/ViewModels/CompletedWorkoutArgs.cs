using System;

namespace UiChallengeWorkoutApp.Models
{
    public class CompletedWorkoutArgs
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Days { get; set; }
    }
}