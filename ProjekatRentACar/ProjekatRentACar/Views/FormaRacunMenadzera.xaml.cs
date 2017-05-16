using ProjekatRentACar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatRentACar.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaRacunMenadzera : Page
    {
        public ObservableCollection<Proba> probe = new ObservableCollection<Proba>();


        public FormaRacunMenadzera()
        {
            this.InitializeComponent();
            probe.Add(new Proba("/Assets/polo.png",
                "Senadin Terović", 
                "Datum rođenja: 07.03.1992", 
                "Broj telefona: 0611111110",
                "Email: neko@gmail.com",
                "Država: BiH",
                "Ulica: Zmaja od Bosne 51",
                "Poštanski broj: 71000",
                "Uposlenik od: 02.05.2016"));

            probe.Add(new Proba("/Assets/polo.png",
                "Almedin Mrnđić",
                "Datum rođenja: 07.03.1992",
                "Broj telefona: 0611111110",
                "Email: neko@gmail.com",
                "Država: BiH",
                "Ulica: Zmaja od Bosne 51",
                "Poštanski broj: 71000",
                "Uposlenik od: 02.05.2016"));

            probe.Add(new Proba("/Assets/polo.png",
                "Ehvan Građanin",
                "Datum rođenja: 07.03.1992",
                "Broj telefona: 0611111110",
                "Email: neko@gmail.com",
                "Država: BiH",
                "Ulica: Zmaja od Bosne 51",
                "Poštanski broj: 71000",
                "Uposlenik od: 02.05.2016"));

            probe.Add(new Proba("/Assets/polo.png",
                "Cogo Emir",
                "Datum rođenja: 07.03.1992",
                "Broj telefona: 0611111110",
                "Email: neko@gmail.com",
                "Država: BiH",
                "Ulica: Zmaja od Bosne 51",
                "Poštanski broj: 71000",
                "Uposlenik od: 02.05.2016"));
        }
    }
}
