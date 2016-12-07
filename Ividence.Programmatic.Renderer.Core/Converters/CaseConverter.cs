using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Data;

namespace Ividence.Programmatic.Renderer.Core.Converters
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class UpperCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var str = value as String;
            if (str != null) return str.ToUpper(culture);
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
