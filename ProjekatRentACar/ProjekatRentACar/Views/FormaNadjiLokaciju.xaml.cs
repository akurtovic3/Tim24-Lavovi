using ProjekatRentACar.Models;
using ProjekatRentACar.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class FormaNadjiLokaciju : Page
    {
        public FormaNadjiLokaciju()
        {
            this.InitializeComponent();
            DataContext = new NadjiLokacijuViewModel();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPageViewModel.Instance.changeSelectedItemTo(3);
     
           (DataContext as NadjiLokacijuViewModel).isUp = (Boolean)e.Parameter;
            

        }

        private void SearchBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            //Narušava se malo MVVM, ali ovo je najlakši način, jer nemaju Commande za TextChanged
            (DataContext as NadjiLokacijuViewModel).filterSuggestedItems(((AutoSuggestBox)sender).Text);
        }


        private void SearchBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            (sender as AutoSuggestBox).Text = (args.SelectedItem as Lokacija).Naziv;
            (DataContext as NadjiLokacijuViewModel).performSelectedLocation(args.SelectedItem as Lokacija);
            
        }

        
    }
}
