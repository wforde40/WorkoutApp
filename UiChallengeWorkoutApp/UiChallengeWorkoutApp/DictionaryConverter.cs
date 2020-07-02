using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UiChallengeWorkoutApp.ViewModels;
using Xamarin.Forms;

namespace UiChallengeWorkoutApp
{
    [ContentProperty("")]
    class DictionaryConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (value != null)
            //{
            //    var model = value as WorkoutChoiceViewModel;
            //    var tabList = model.Tabs;
            //    var key = int.Parse(parameter as string);

            //    return tabList[key];

            //}

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
