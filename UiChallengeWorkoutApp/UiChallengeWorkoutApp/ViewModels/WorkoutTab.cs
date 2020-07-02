using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;


namespace UiChallengeWorkoutApp.ViewModels
{
    public class WorkoutTab : BaseViewModel
    {
        private string _text;
        public string Text 
        { 
            get => _text;
            set 
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        private bool _selected;
        public bool Selected 
        {
            get => _selected; 
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }




    }
}
