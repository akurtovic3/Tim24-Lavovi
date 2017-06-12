using ProjekatRentACar.Helper;
using ProjekatRentACar.Models;
using ProjekatRentACar.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace ProjekatRentACar.ViewModels
{
    public class DetaljiVozacaViewModel
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string telefon { get; set; }
        public string email { get; set; }
        public bool PristanakNaUvjete { get; set; }
        
        public ICommand Dalje { get; set; }


        public Najam najam { get; set; }
        NavigationService navigacija;

        public DetaljiVozacaViewModel(Najam najam)
        {
            this.najam = najam;
            id = App._id;
            ime = App._ime;
            prezime = App._prezime;
            telefon = App._telefon;
            email = App._email;
            PristanakNaUvjete = false;
            Dalje = new RelayCommand<object>(idiDalje);
            navigacija = new NavigationService();
        }

        private void idiDalje(object parameter)
        {
            if (PristanakNaUvjete)
            {
                navigacija.Navigate(typeof(FormaPlacanje));
            }else
            {
                showMessageDialog();
            }

        }
        private async void showMessageDialog()
        {
            MessageDialog ms = new MessageDialog("Morate pristati na uslove navedene u ugovoru!");
            await ms.ShowAsync();
        }

        
    }
}
