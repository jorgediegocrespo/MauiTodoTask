using System.Globalization;

namespace TaskManager.Converter;

public class InvertedBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool result)
            return !result;

        throw new ArgumentException("Value is not a valid boolean", nameof(value));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool result)
            return !result;

        throw new ArgumentException("Value is not a valid boolean", nameof(value));
    }
}
