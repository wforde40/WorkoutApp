using System;
using System.Collections.Generic;
using UiChallengeWorkoutApp.Views;
using Xamarin.Forms;

namespace UiChallengeWorkoutApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            tabBar.Items.Add(new ShellContent()
            {
                Title = "Home",
                Icon = "tab_feed.png",
                Content = new WorkoutChoicePage(),
            }) ;
        }
    }
}
