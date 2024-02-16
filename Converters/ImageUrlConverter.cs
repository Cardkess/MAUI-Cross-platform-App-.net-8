using MAUI.Commons;

namespace MAUI.Converters
{
    public class ImageUrlConverter : IValueConverter
    {
        public AppSettings? AppSettings { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null || AppSettings == null || parameter == null)
                return null;

            switch (parameter)
            {
                case ImageType.ProductImage:
                    return $"{AppSettings.BaseWebUri}/image/file/product/mobile-image/{value.ToString()}?g={Guid.NewGuid()}";

                case ImageType.ProductOption:
                    return $"{AppSettings.BaseWebUri}/image/file/ingredient/{value.ToString()}?g={Guid.NewGuid()}";

                default:
                    return string.Empty;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
