using System;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Property.Setter.UWP.Common
{
    //[ValueConversion(typeof(bool),
    //    typeof(Visibility))]
    public class BoolToVisibilityConverter : IValueConverter
    {
        private readonly bool _isInverted;

        private static BoolToVisibilityConverter _nullToVisibilityConverter;

        public static BoolToVisibilityConverter Default
        {
            get
            {
                return _nullToVisibilityConverter = _nullToVisibilityConverter
                                                    ?? new BoolToVisibilityConverter(false);
            }
        }

        private static BoolToVisibilityConverter _invertedBoolToVisibilityConverter;

        public static BoolToVisibilityConverter Invert
        {
            get
            {
                return _invertedBoolToVisibilityConverter = _invertedBoolToVisibilityConverter
                                                            ?? new BoolToVisibilityConverter(true);
            }
        }

        public BoolToVisibilityConverter()
        {
            
        }

        public BoolToVisibilityConverter(bool isInverted)
        {
            _isInverted = isInverted;
        }

        public object Convert(
            object value,
            Type targetType,
            object parameter,
            string language)
        {
            if (bool.TryParse(
                    value?.ToString(),
                    out bool result) == false)
            {
                throw new ArgumentException("BoolToVisibilityConverter received non-bool value");
            }

            if (_isInverted)
            {
                result = !result;
            }

            return result
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            string language)
        {
            throw new NotImplementedException();
        }
    }
}
