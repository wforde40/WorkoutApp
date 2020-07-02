using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UiChallengeWorkoutApp.MobileAppService.Models;
using UiChallengeWorkoutApp.Models;

namespace UiChallengeWorkoutApp.Services
{

    public interface IExerciseDataStore
    {
        Task<bool> AddAsync(Exercise item);
        Task<bool> UpdateAsync(Exercise item);
        Task<bool> DeleteAsync(int id);
        Task<Workout> GetAsync(int id);
        Exercise Get(int id);
        Task<IEnumerable<Exercise>> GetAsync(bool forceRefresh = false);
        Task<Workout> GetRandomAsync(string category, string type);
        Task<IEnumerable<WorkoutCategory>> GetCategories();
        Task<IEnumerable<WorkoutType>> GetTypes();
        Task<IEnumerable<WorkoutDayData>> GetCompletedWorkouts(CompletedWorkoutArgs args);
        Task<WorkoutDayData> AddCompletedWorkout(WorkoutDayData data);
    }

}
