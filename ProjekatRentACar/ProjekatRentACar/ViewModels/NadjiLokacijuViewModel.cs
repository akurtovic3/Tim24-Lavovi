using ProjekatRentACar.Helper;
using ProjekatRentACar.Models;
using ProjekatRentACar.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

namespace ProjekatRentACar.ViewModels
{
    public class NadjiLokacijuViewModel
    {
        IMobileServiceTable<Lokacija> lokacijaTabela = App.MobileService.GetTable<Lokacija>();

       /*   private ObservableCollection<Lokacija> selectionItems = new ObservableCollection<Lokacija> {
            new Lokacija("Sarajevo International Airport",new Geopoint(new BasicGeoposition() { Latitude = 43.8247348, Longitude = 18.3291708}) ,"Kurta Schorka 36","Opis neki bla bla radi sto posto"),
            new Lokacija("Tuzla International Airport",new Geopoint(new BasicGeoposition() { Latitude = 44.4586506, Longitude = 18.7226377}) ,"Kurta Schorka 36","Opis neki bla bla radi sto posto")
       };*/
       private ObservableCollection<Lokacija> selectionItems { get; set; }

        public ObservableCollection<Lokacija> FilteredItems { get; set; }
        public Helper.INavigationService navigacija { get; set; }


        public NadjiLokacijuViewModel(bool returnLocation = false) 
        {
            FilteredItems = new ObservableCollection<Lokacija>();
            selectionItems = new ObservableCollection<Lokacija>();
            navigacija = new NavigationService();
            try
            {
                uradiTask().GetAwaiter();
            }
            catch(Exception ex)
            {
                MessageDialog msgDialogEror = new MessageDialog("Error: " + ex.ToString());
                msgDialogEror.ShowAsync();
            }
        }

        private async Task  uradiTask()
        {
            IEnumerable<Lokacija> x =   await lokacijaTabela.ReadAsync(); 
            selectionItems.Clear();
            foreach (Lokacija lc in x)
            {
                selectionItems.Add(lc);
            }
            Debug.WriteLine((x.ElementAt(0) as Lokacija).Naziv);
        }

        public void filterSuggestedItems(string autoSuggestBoxText)
        {
            //Pitanje za cogu: Drugaciji nacin kako da ovo dolje radi???
            FilteredItems.Clear();
            var filtered = selectionItems.Where(l => (l.Naziv.Contains(autoSuggestBoxText) || l.Naziv.ToLower().Contains(autoSuggestBoxText)));
            foreach (Lokacija s in filtered)
            {
                s.LokacijaMjesta = new Geopoint(new BasicGeoposition() { Longitude = s.Duzina, Latitude = s.Sirina });
                FilteredItems.Add(s);
            }

        }

        public void performSelectedLocation(Lokacija selectedItem)
        {
            navigacija.Navigate(typeof(FormaDetaljiLokacije), selectedItem);
        }

        
    }
}
