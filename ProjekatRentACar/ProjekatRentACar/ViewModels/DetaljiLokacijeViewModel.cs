using ProjekatRentACar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.ViewModels
{
    public class DetaljiLokacijeViewModel
    {
        public Lokacija OdabranaLokacija { get; set; }
       // public ObservableCollection<Lokacija> Locations { get; private set; }
       

        public DetaljiLokacijeViewModel(Lokacija lokacija)
        {
            OdabranaLokacija = lokacija;
   //         Locations = new ObservableCollection<Lokacija>();
//Locations.Add(OdabranaLokacija);
        }
    }
}
