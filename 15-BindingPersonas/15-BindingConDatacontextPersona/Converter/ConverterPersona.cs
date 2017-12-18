using _15_BindingConDatacontextPersona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace _15_BindingConDatacontextPersona.Converter
{
    class ConverterPersona: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            clsPersona p = (clsPersona) value;
            return p;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            clsPersona p = (clsPersona)value;
            return p;
        }
    }
}
