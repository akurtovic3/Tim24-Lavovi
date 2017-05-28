using ProjekatRentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ProjekatRentACar.Helper
{
    public class LokacijaPreuzimanjaKonverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if((value as Lokacija).Naziv == null)
            {
                return "Lokacija preuzimanja";
            }else
            {
                return (value as Lokacija).Naziv;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
