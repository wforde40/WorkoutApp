using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UiChallengeWorkoutApp.MobileAppService.Models
{
    public interface IWorkoutRepository
    {
        void Add(Workout exercise);
        void Update(Workout exercise);
        Workout Remove(int id);
        Workout Get(int id);
        IEnumerable<Workout> GetAll();
        Workout GetRandom(string category, string type);
        IEnumerable<WorkoutCategory> GetCategories();
        IEnumerable<WorkoutType> GetTypes();
        IEnumerable<CompletedWorkout> GetCompletedWorkouts(int id, DateTime startDate, DateTime endDate);
        CompletedWorkout AddCompletedWorkout(CompletedWorkout value);
    }
}
