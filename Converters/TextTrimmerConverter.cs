using System.Globalization;


namespace MAUI.Converters
{
    public class TextTrimmerConverter : IValueConverter
    {
        public int MaxLength { get; set; } = 156; // Default maximum length

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check the MaxLength property value
            int maxLength = MaxLength;
            if (parameter != null)
            {
                if (int.TryParse(parameter.ToString(), out int parsedMaxLength))
                {
                    maxLength = parsedMaxLength;
                }
            }

            if (value is string text && text.Length > maxLength)
            {
                return text.Substring(0, maxLength) + "...";
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
