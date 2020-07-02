using Android.Support.V7.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace UiChallengeWorkoutApp.Droid.Renderers
{
    public class TransparentNavbar : ShellToolbarAppearanceTracker
    {
        public TransparentNavbar(IShellContext shellContext) : base(shellContext)
        {
        }

        public override void SetAppearance(Toolbar toolbar, IShellToolbarTracker toolbarTracker, ShellAppearance appearance)
        {
            base.SetAppearance(toolbar, toolbarTracker, appearance);
            toolbar.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
        protected override void SetColors(Toolbar toolbar, IShellToolbarTracker toolbarTracker, Color foreground, Color background, Color title)
        {
            var bg = Color.Red;
            base.SetColors(toolbar, toolbarTracker, foreground, bg, title);
        }
    }
}