using ProjekatRentACar.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ProjekatRentACar.Views;

namespace ProjekatRentACar.ViewModels
{
    class InformacijeViewModel
    {
        public ICommand ONama { get; set; }
        public ICommand Privatnost { get; set; }
        public ICommand UsloviKoristenja { get; set; }
        public INavigationService navigacija { get; set; }

        public InformacijeViewModel()
        {
            ONama = new RelayCommand<object>(prikaziONama);
            Privatnost = new RelayCommand<object>(prikaziPrivatnost);
            UsloviKoristenja = new RelayCommand<object>(prikaziUsloveKoristenja);
            navigacija = new NavigationService();
    }

        void prikaziONama(object param)
        {
            navigacija.Navigate(typeof(FormaONama));
        }

        void prikaziPrivatnost(object param)
        {
            navigacija.Navigate(typeof(FormaPrivatnost));
        }

        void prikaziUsloveKoristenja(object param)
        {
            navigacija.Navigate(typeof(FormaUvjetiKoristenja));
        }
    }
}
