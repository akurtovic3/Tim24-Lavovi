using ProjekatRentACar.Helper;
using ProjekatRentACar.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjekatRentACar.ViewModels
{
    public class OdabirLokacijeIDatumaViewModel
    {
        public ICommand Ponude { get; set; }
        public Helper.INavigationService NavigationService { get; set; }

        public OdabirLokacijeIDatumaViewModel()
        {
            Ponude = new RelayCommand<object>(prikaziPonude, moguLiSePrikazatiPonude);
            NavigationService = new NavigationService();
        }

        public bool moguLiSePrikazatiPonude(object parametar)
        {
            return true;
        }

        public void prikaziPonude(object parametar)
        {
            NavigationService.Navigate(typeof(FormaListaVozila));
            
        }
    }
}
