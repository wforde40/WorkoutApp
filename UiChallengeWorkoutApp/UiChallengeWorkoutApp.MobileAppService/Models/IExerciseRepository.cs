using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UiChallengeWorkoutApp.MobileAppService.Models
{
    public interface IExerciseRepository
    { 
        void Add(Exercise exercise);
        void Update(Exercise exercise);
        Exercise Remove(int id);
        Exercise Get(int id);
        IEnumerable<Exercise> GetAll(); 

        

    }
}
