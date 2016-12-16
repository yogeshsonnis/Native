using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Data;

namespace Ividence.Programmatic.Renderer.Core.Converters
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class IsNotNullNorEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value is string && value != null && ((string)value).Length > 0) ||
                value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
