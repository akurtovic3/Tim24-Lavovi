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
    /// 

    public sealed partial class FormaKorisnickiRacun : Page
    {
        public ObservableCollection<Proba> probe = new ObservableCollection<Proba>();

        public FormaKorisnickiRacun()
        {
            this.InitializeComponent();

            probe.Add(new Proba("Polo", "Od: 01.01.2017.", "Do: 05.01.2017", "/Assets/polo.png"));
            probe.Add(new Proba("Golf", "Od: 01.01.2017.", "Do: 05.01.2017", "/Assets/polo.png"));
            probe.Add(new Proba("Renault", "Od: 01.01.2017.", "Do: 05.01.2017", "/Assets/polo.png"));
            probe.Add(new Proba("Peugeot", "Od: 01.01.2017.", "Do: 05.01.2017", "/Assets/polo.png"));
            probe.Add(new Proba("Mercedes", "Od: 01.01.2017.", "Do: 05.01.2017", "/Assets/polo.png"));

        }
    }
}
