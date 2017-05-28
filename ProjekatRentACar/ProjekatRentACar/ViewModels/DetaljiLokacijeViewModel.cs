using ProjekatRentACar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatRentACar.Helper;
using ProjekatRentACar.Views;


namespace ProjekatRentACar.ViewModels
{
    public class DetaljiLokacijeViewModel
    {
        public ICommand RezervisiOvdjeCommand { get; set; }
        private Boolean isUp;
        public Lokacija OdabranaLokacija { get; set; }
        public INavigationService navigacija { get; set; }

        // public ObservableCollection<Lokacija> Locations { get; private set; }


        public DetaljiLokacijeViewModel(List <object> lista)
        {
            OdabranaLokacija = (lista[0] as Lokacija);
            isUp = (Boolean)lista[1];
            RezervisiOvdjeCommand = new RelayCommand<object>(upisiUOdabirLokacije,p => true);
            navigacija = new NavigationService();
        }

        private void upisiUOdabirLokacije(object parameter)
        {
            navigacija.Navigate(typeof(FormaOdabirLokacijeIDatuma), new List<object>() { OdabranaLokacija, isUp});
        }
    }
}
