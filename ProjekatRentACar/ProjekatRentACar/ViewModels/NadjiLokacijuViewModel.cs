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

namespace ProjekatRentACar.ViewModels
{
    public class NadjiLokacijuViewModel
    {
        
        private ObservableCollection<Lokacija> selectionItems = new ObservableCollection<Lokacija> { new Lokacija("Sarajevo International Airport",new Geopoint(new BasicGeoposition() { Latitude = 43.8247348, Longitude = 18.3291708}) ,"Kurta Schorka 36","Opis neki bla bla radi sto posto"),
            new Lokacija("Tuzla International Airport",new Geopoint(new BasicGeoposition() { Latitude = 44.4586506, Longitude = 18.7226377}) ,"Kurta Schorka 36","Opis neki bla bla radi sto posto")
       };

        public ObservableCollection<Lokacija> FilteredItems { get; set; }
        public Helper.INavigationService navigacija { get; set; }


        public NadjiLokacijuViewModel(bool returnLocation = false) 
        {
            FilteredItems = new ObservableCollection<Lokacija>(selectionItems);
            navigacija = new NavigationService();
        }

        public void filterSuggestedItems(string autoSuggestBoxText)
        {
            //Pitanje za cogu: Drugaciji nacin kako da ovo dolje radi???
            FilteredItems.Clear();
            var filtered = selectionItems.Where(p => (p as Lokacija).Naziv.StartsWith(autoSuggestBoxText)).ToArray();
            foreach (Lokacija s in filtered)
            {
                FilteredItems.Add(s);
            }
        }

        public void performSelectedLocation(Lokacija selectedItem)
        {
            navigacija.Navigate(typeof(FormaDetaljiLokacije), selectedItem);
            Debug.WriteLine(selectedItem);
        }

        
    }
}
