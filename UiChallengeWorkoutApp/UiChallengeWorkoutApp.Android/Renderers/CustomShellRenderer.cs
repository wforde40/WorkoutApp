using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

//[assembly: ExportRenderer(typeof(UiChallengeWorkoutApp.AppShell), typeof(UiChallengeWorkoutApp.Droid.Renderers.CustomShellRenderer))]
namespace UiChallengeWorkoutApp.Droid.Renderers
{

    public class CustomShellRenderer : ShellRenderer
    {

        public CustomShellRenderer(Context context) : base(context)
        {

        }

        protected override IShellToolbarAppearanceTracker CreateToolbarAppearanceTracker()
        {
            return new TransparentNavbar(this);
        }
    }
}