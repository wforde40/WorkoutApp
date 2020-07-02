using UiChallengeWorkoutApp.Models;

namespace UiChallengeWorkoutApp.Services
{
    internal interface IWorkoutProvider
    {
        Workout GetWorkout(string category = null);
    }
}