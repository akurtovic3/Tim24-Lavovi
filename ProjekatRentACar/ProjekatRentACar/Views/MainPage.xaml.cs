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
using ProjekatRentACar.Views;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjekatRentACar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainFrame.Navigate(typeof(FormaOdabirOpreme));
            App.splitViewFrame = MainFrame;
        }

        private void NavigationButton_Click(object sender, RoutedEventArgs e)
        {
            MainSplitView.IsPaneOpen = !MainSplitView.IsPaneOpen;
        }

        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (MenuListBox.SelectedIndex)
            {
                case 0:
                    MainFrame.Navigate(typeof(FormaOdabirLokacijeIDatuma));
                    break;
                case 1:
                    MainFrame.Navigate(typeof(FormaKorisnickiRacun));
                    break;
                case 2:
                    MainFrame.Navigate(typeof(FormaPonudaPopust));
                    break;
                case 3:
                    MainFrame.Navigate(typeof(FormaNadjiLokaciju));
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    MainFrame.Navigate(typeof(FormaPomocIKontakt));
                    break;
                case 7:
                    MainFrame.Navigate(typeof(FormaInformacije));
                    break;
                case 8:
                    MainFrame.Navigate(typeof(FormaPostavke));
                    break;
            }
        }
    }
}
