using ProjekatRentACar.Models;
using ProjekatRentACar.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatRentACar.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaPonudaPopust : Page
    {
        //public ObservableCollection<ListaVozilaProba> vozila = new ObservableCollection<ListaVozilaProba>();

        public ObservableCollection<Vozilo> vozila = new ObservableCollection<Vozilo>();
        private VozilaDataSource vozilaDS;
        public VozilaDataSource VozilaDS
        {
            get
            {
                return vozilaDS;
            }

            set
            {
                vozilaDS = value;
            }
        }

        public FormaPonudaPopust()
        {
            this.InitializeComponent();
            VozilaDS = new VozilaDataSource();
            vozilaDS.preuzmiVozila(new DateTime(2017,5,1), new DateTime(2017,5,3), restoraniLoaded);
        }

        private void restoraniLoaded()
        {
            vozila.Clear();
            foreach (Vozilo v in VozilaDS.Vozila)
            {
                vozila.Add(v);
            }
        }

        private void ispisi()
        {
            foreach (Vozilo v in vozila)
            {
                Debug.WriteLine(v.Model);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPageViewModel.Instance.changeSelectedItemTo(2);
        }

       

    }
}
