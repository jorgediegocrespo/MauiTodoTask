using System.Globalization;

namespace TaskManager.Converter;

public class TaskPriorityToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is TaskPriority result)
            return result switch
            {
                TaskPriority.High => Colors.Red,
                TaskPriority.Medium => Colors.Yellow,
                _ => Colors.Green
            };

        throw new ArgumentException("Value is not a valid TaskPriority", nameof(value));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
