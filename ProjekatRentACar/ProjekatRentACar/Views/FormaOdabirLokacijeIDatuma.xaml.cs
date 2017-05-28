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
using ProjekatRentACar.ViewModels;
using ProjekatRentACar.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatRentACar.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaOdabirLokacijeIDatuma : Page
    {
        public FormaOdabirLokacijeIDatuma()
        {
            this.InitializeComponent();
            DataContext = new OdabirLokacijeIDatumaViewModel();
            NavigationCacheMode = NavigationCacheMode.Required;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPageViewModel.Instance.changeSelectedItemTo(0);
            if (!(e.Parameter == null || string.IsNullOrWhiteSpace(e.Parameter.ToString())))
            {
                var lista = (List<object>)e.Parameter;
                (DataContext as OdabirLokacijeIDatumaViewModel).KrajnjaLokacija = (Lokacija)(lista.ElementAt(0));
                if ((Boolean)(lista.ElementAt(1)) == true)
                {
                    (DataContext as OdabirLokacijeIDatumaViewModel).PocetnaLokacija = (Lokacija)(lista.ElementAt(0));
                }
            }
        }
    }
}
