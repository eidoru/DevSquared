using DevSquared.ViewModels;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DevSquared.Converters
{
    internal class ViewModelToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is LoginViewModel || value is RegisterViewModel)
            {
                return Visibility.Collapsed;
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
