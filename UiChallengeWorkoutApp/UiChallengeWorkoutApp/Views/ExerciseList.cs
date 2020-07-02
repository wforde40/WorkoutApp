using System;
using System.Collections.Generic;
using System.Text;
using UiChallengeWorkoutApp.ViewModels;
using Xamarin.Forms;
using System.Linq;
using System.Windows.Input;

namespace UiChallengeWorkoutApp.Views
{
    public class ExerciseList : ContentView
    {

        public static readonly BindableProperty ExercisesProperty =
            BindableProperty.Create(nameof(Exercises), typeof(IEnumerable<ExerciseViewModel>), typeof(ExerciseList), propertyChanged:ExercisesChanged);

        public static readonly BindableProperty CompletedCommandProperty =
            BindableProperty.Create(nameof(CompletedCommand), typeof(ICommand), typeof(ExerciseList));

        private static void ExercisesChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var list = bindable as ExerciseList;
            list.MakeList();
        }

        public IEnumerable<ExerciseViewModel> Exercises 
        {
            get => GetValue(ExercisesProperty) as IEnumerable<ExerciseViewModel>;
            set => SetValue(ExercisesProperty, value);
        }

        public ICommand CompletedCommand
        {
            get => GetValue(CompletedCommandProperty) as ICommand;
            set => SetValue(CompletedCommandProperty, value);
        }

        ICommand ItemCheckedCommand { get; }

        private Grid ExerciseGrid { get; set; }

        public ExerciseList()
        {
            ItemCheckedCommand = new Command(() => CheckMarkTapped());

            ExerciseGrid = new Grid()
            {
                BackgroundColor = Color.FromHex("#F3F3F3"),
            };

            Content = ExerciseGrid;
        }

        public  void MakeList()
        {
            
            for (var i = 0; i < Exercises.Count(); i++)
            {
                var test = new ExerciseListItem()
                {
                    BindingContext = Exercises.ElementAt(i),
                    Checked = ItemCheckedCommand,
                };

                ExerciseGrid.RowDefinitions.Add(new RowDefinition()
                {
                    Height = GridLength.Star
                });

                ExerciseGrid.Children.Add(test, 0, i);
            }
        }

        private void CheckMarkTapped()
        {
            if (ExerciseGrid.Children
                .OfType<ExerciseListItem>()
                .All(p => (p.BindingContext as ExerciseViewModel).Completed == true))
            {
                CompletedCommand.Execute(null);
            }

        }
    }
}
