using System;
using System.Collections.Generic;
using System.Text;
using UiChallengeWorkoutApp.MobileAppService.Models;

namespace UiChallengeWorkoutApp.ViewModels
{
    public class ExerciseViewModel : BaseViewModel
    {
        public string Index { get; set; }
        public string Name { get; set; }
        public string Repetitions { get; set; }
        public bool Completed { get; set; }
        public bool IsBlank { get; set; }
        public bool IsRest { get; set; }
        public bool IsNotRest { get; set; }


        public ExerciseViewModel(string index = "", string name = "", string repetitions ="", bool completed = false, bool isRest = false, bool isBlank = true)
        {
            Index = index;
            Name = name;
            Repetitions = repetitions;
            Completed = completed;
            IsRest = isRest;
            IsNotRest = !isRest;
            IsBlank = true;
        }

        public ExerciseViewModel(Exercise exercise)
        {
            Index = 0.ToString();
            Name = exercise.Name;
            //Repetitions = exercise.;
            Completed = false;
            IsRest = false;
            IsNotRest = !IsRest;
        }
    }
}
