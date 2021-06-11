using System;
using System.Linq;
using System.Windows.Data;

namespace StoreTestWPF.ViewModel.Utils
{
    public class PriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal amount = System.Convert.ToInt32(value) / 100M;
            return string.Format("{0:C}", amount);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string number = new string(value.ToString().Where(char.IsDigit).TakeLast(9).ToArray());

            return System.Convert.ToInt32(number);
        }
    }
}