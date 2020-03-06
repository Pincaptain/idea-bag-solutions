using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HouseholdBudgetProgram.Converters
{
    #region Methods
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool visible)
            {
                if (visible)
                {
                    return Visibility.Visible;
                }

                return Visibility.Hidden;
            }

            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                if (visibility == Visibility.Visible)
                {
                    return true;
                }

                return false;
            }

            return false;
        }
    }
    #endregion
}
