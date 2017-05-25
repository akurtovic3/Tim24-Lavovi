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
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            MainPageViewModel.Instance.changeSelectedItemTo(3);
        }

        private string[] selectionItems = new string[] { "Sarajevo", "Mostar", "Konjic", "Bihać", "Tuzla", "Zenica" };
        private void SearchBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            var autoSuggestBox = (AutoSuggestBox)sender;
            var filtered = selectionItems.Where(p => p.StartsWith(autoSuggestBox.Text)).ToArray();
            autoSuggestBox.ItemsSource = filtered;
        }


        private void SearchBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            Debug.WriteLine("RADI");
        }
    }
}
