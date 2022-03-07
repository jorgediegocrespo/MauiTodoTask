//TODO Jorge
using System.Globalization;

namespace TaskManager.Converter;

public class IntToBoolConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int result)
            return result > 0;

        throw new ArgumentException("Value is not a valid int", nameof(value));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
