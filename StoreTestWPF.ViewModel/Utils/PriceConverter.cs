using System;
using System.Windows.Data;

namespace StoreTestWPF.ViewModel.Utils
{
    public class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is decimal)
            { 
                return string.Format("{0:C}", value); 
            }
            else throw new Exception("The input must be decimal");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal result;
            if (Decimal.TryParse(value.ToString(), out result))
            {
                return result;
            }
            else throw new Exception("The input must be convertable to decimal");
        }
    }
}