using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ProjekatRentACar.Models;
using System.Collections.ObjectModel;
using ProjekatRentACar.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatRentACar.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaListaVozila : Page
    {
        public ObservableCollection<ListaVozilaProba> vozila = new ObservableCollection<ListaVozilaProba>();

        public FormaListaVozila()
        {
            this.InitializeComponent();

            vozila.Add(new ListaVozilaProba("Mercedes-Benz", "S Class", "Limuzina", "Po danu 86 KM", "/Assets/mercedes.png"));
            vozila.Add(new ListaVozilaProba("Škoda", "Octavia", "Limuzina", "Po danu 42 KM", "/Assets/octavia.png"));
            vozila.Add(new ListaVozilaProba("Volkswagen", "Golf 7", "Kompakt", "Po danu 39 KM", "/Assets/golf7.png"));
            vozila.Add(new ListaVozilaProba("Volvo", "S60", "Limuzina", "Po danu 51 KM", "/Assets/volvo_s60.png"));
            vozila.Add(new ListaVozilaProba("Volkswagen", "Polo", "Kompakt", "Po danu 45 KM", "/Assets/polo.png"));
            vozila.Add(new ListaVozilaProba("BMW", "5 series", "Limuzina", "Po danu 63 KM", "/Assets/bmw-5-series.png"));
            vozila.Add(new ListaVozilaProba("Kia", "Ceed", "Kompakt", "Po danu 49 KM", "/Assets/kia_ceed_sportswagon.png"));
            vozila.Add(new ListaVozilaProba("Volkswagen", "Passat Variant", "Karavan", "Po danu 78 KM", "/Assets/iris.png"));
        }

       
    }
}
