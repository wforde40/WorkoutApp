using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Net;
using Android.Graphics;

namespace UiChallengeWorkoutApp.Droid
{
    [Activity(Label = "UiChallengeWorkoutApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            System.Net.ServicePointManager.ServerCertificateValidationCallback = (_, __, ___, ____) => true;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.SetFlags();
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Window.DecorView.SystemUiVisibility = (Android.Views.StatusBarVisibility)Android.Views.SystemUiFlags.LightStatusBar;
            SetStatusBarColor(Android.Graphics.Color.ParseColor("#F5F7F9"));

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}