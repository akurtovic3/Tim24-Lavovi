using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace ProjekatRentACar.Helper
{
    public class ErrorToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ICollection<string> errors = value as ICollection<string>;
            if (errors.Count != 0)
            {
                return (new SolidColorBrush(Colors.DarkRed));
                
            }
            return (new SolidColorBrush(Colors.Gray));
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
