using System;
using System.Collections.Generic;
using System.Text;
using UiChallengeWorkoutApp.Models;

namespace UiChallengeWorkoutApp.Services
{
    class RandomWorkoutProvider : IWorkoutProvider
    {
        public Workout  GetWorkout(string category = null)
        {
            return new Workout();   
        }
    }
}
