using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows.Data;

namespace Ividence.Programmatic.Renderer.Core.Converters
{
    public abstract class ConverterBase : IValueConverter
    {
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class OperatorConverterBase : ConverterBase
    {
        private string operatorName;

        protected OperatorConverterBase(string operatorName)
        {
            this.operatorName = operatorName;
        }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value == null) return false;

                var op = value.GetType().GetMethod(this.operatorName, BindingFlags.Static | BindingFlags.Public);
                if (op != null)
                {
                    var valueType = value.GetType();
                    var paramType = parameter?.GetType();

                    if (valueType != paramType)
                    {
                        var conv = TypeDescriptor.GetConverter(valueType);
                        if (conv.CanConvertFrom(paramType))
                        {
                            parameter = conv.ConvertFrom(parameter);
                        }
                    }

                    var res = op.Invoke(null, new object[] { value, parameter });
                    if (res is bool) return (bool)res;
                }
            }
            catch(Exception exc)
            {
                Log.Error("OperatorConverterBase", "Unexpected error", exc, 100);
            }
            return false;
        }
    }

    public class EqualConverter : ConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? value.Equals(parameter) : parameter == null;
        }
    }

    public class NotEqualConverter : ConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? !value.Equals(parameter) : parameter != null;
        }
    }

    public class GreaterThanConverter : OperatorConverterBase
    {
        public GreaterThanConverter() : base("op_GreaterThan") { }
    }

    public class GreaterThanOrEqualConverter : OperatorConverterBase
    {
        public GreaterThanOrEqualConverter() : base("op_GreaterThanOrEqual") { }
    }

    public class LessThanConverter : OperatorConverterBase
    {
        public LessThanConverter() : base("op_LessThan") { }
    }

    public class LessThanOrEqualConverter : OperatorConverterBase
    {
        public LessThanOrEqualConverter() : base("op_LessThanOrEqual") { }
    }

    public class NotConverter : ConverterBase
    {
        public IValueConverter Converter { get; set; }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var res = this.Converter?.Convert(value, targetType, parameter, culture);
            return res is bool ? !(bool)res : false;
        }
    }
}