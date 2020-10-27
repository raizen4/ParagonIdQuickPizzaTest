using System;
using System.Globalization;
using ParagonIdTest.Enums;
using Xamarin.Forms;

namespace ParagonIdTest.Converters
{
    class PizzaStatusConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var status = (PizzaStatus)value;

            if (status == PizzaStatus.InProgress)
            {
                return "In Progress";
            }
            else
                return "Completed";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
          return null;
        }
    }
}