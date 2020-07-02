using System;
using System.Collections;

namespace UiChallengeWorkoutApp.Models
{
    public class WorkoutDayData 
    {   
        public int Id { get; set; }
        public int WorkoutID { get; set; }
        public int UserID { get; set; }
        public bool Done { get; set; }
        public string Day { get => DateToDayMap(WorkoutDate.DayOfWeek); }
        public DateTime WorkoutDate { get; set; }

        public DateTime DateCompleted
        {
            get => WorkoutDate;
            set => WorkoutDate = value;
        }

        private static string DateToDayMap(DayOfWeek day) => day switch
        {
            DayOfWeek.Monday => "M",
            DayOfWeek.Tuesday => "T",
            DayOfWeek.Wednesday => "W",
            DayOfWeek.Thursday => "R",
            DayOfWeek.Friday => "F",
            DayOfWeek.Saturday => "S",
            DayOfWeek.Sunday => "S",
            _ => ""
        };
    }
}