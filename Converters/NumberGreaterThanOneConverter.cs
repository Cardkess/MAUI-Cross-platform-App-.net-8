using System.Globalization;

namespace MAUI.Converters
{
    public class NumberGreaterThanOneConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int intValue)
            {
                return intValue > 1;
            }

            // If the value is not an integer, you might want to handle that case accordingly.
            // For simplicity, we assume it's not greater than one.
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
