using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiChallengeWorkoutApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UiChallengeWorkoutApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExerciseListViewCell : ViewCell
    {
        public string Index { get; set;}
        public string Name { get; set; }
        public string Repititions { get; set; }
        public bool Completed { get; set; }

       
        //public ExerciseListViewCell(ExerciseViewModel viewModel)
        //{
        //    InitializeComponent();

        //    Index = viewModel.Index;
        //    Name = viewModel.Name;
        //    Repititions = viewModel.Repititions;
        //    Completed = viewModel.Completed;

        //    CheckPath.MoveTo(0, 30);
        //    CheckPath.LineTo(30, 60);
        //    CheckPath.LineTo(80, 10);
        //}


        public ExerciseListViewCell()
        {
            InitializeComponent();

            Index = "";
            Name = "";
            Repititions = "";
            Completed = false;
        }


    }
}