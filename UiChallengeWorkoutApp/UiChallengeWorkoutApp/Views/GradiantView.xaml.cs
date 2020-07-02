using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Essentials;

namespace UiChallengeWorkoutApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GradiantView : ContentView
    {
        private SKPath Shape = new SKPath();
        private SKPaint ShapeFill = new SKPaint();

        public GradiantView()
        {
            InitializeComponent();

            var height = (int)DeviceDisplay.MainDisplayInfo.Height + 300;
            var width = (int)DeviceDisplay.MainDisplayInfo.Width;

            InitShape(height / 2, width);
        }

        private void InitShape(int height, int width, int offset = 200)
        {
            var shapeHeight = height;
            var offsetHeight = shapeHeight - offset;

            Shape.MoveTo(0, 0);
            Shape.LineTo(0, shapeHeight);
            Shape.LineTo(width, offsetHeight);
            Shape.LineTo(width, 0);

            ShapeFill.Shader =
                SKShader.CreateLinearGradient(
                new SKPoint(0, 0),
                new SKPoint(width, height),
                new SKColor[] { SKColor.Parse("#9F71F5"), SKColor.Parse("#5337E2") },
                new float[] { .1f, .45f},
                SKShaderTileMode.Repeat
                );
        }


        private void CanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            var canvas = args.Surface.Canvas;
            canvas.Clear();

            canvas.Save();
            canvas.DrawPath(Shape, ShapeFill);
            canvas.Restore();
        }
    }
}