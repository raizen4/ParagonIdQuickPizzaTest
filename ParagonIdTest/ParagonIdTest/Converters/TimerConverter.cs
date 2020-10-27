using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using ParagonIdTest.Models;
using Xamarin.Forms;

namespace ParagonIdTest.Converters
{
    public class TimerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var convertedValue = Helpers.FormatTimeToBake((int) value);

            return convertedValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}