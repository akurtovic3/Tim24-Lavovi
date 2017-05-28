using ProjekatRentACar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ProjekatRentACar.Helper
{
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            List<String> tipovi = new List<string>() { "Kompakt", "Limuzina", "Terenac", "Karavan", "Kupe", "Kombi"};
            return tipovi.ElementAt((int)((TipVozila)value));


    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
