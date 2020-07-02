using System;
using System.Collections.Generic;
using System.Text;

namespace UiChallengeWorkoutApp.Models
{
    class WorkoutDateComparer : IEqualityComparer<WorkoutDayData>
    {
        public bool Equals(WorkoutDayData x, WorkoutDayData y)
        {
            var test = DateTime.Compare(x.WorkoutDate.Date, y.WorkoutDate.Date) == 0;
            return test;
        }

        public int GetHashCode(WorkoutDayData obj)
        {
            return -367569312 + obj.GetHashCode();
        }
    }
}
