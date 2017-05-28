using ProjekatRentACar.Models;
using ProjekatRentACar.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private Helper.INavigationService NavigationService { get; set; }
        private MenuItem selectedItem { get; set; }
        public MenuItem SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                promjeniFrame(selectedItem.Tag);
                OnNotifyPropertyChanged("SelectedItem");
            }
        }

        private void promjeniFrame(int tag)
        {
            switch (tag){
                case 0:
                    NavigationService.Navigate(typeof(FormaOdabirLokacijeIDatuma));
                    break;
                case 1:
                    NavigationService.Navigate(typeof(FormaPrijava));
                    break;
                case 2:
                    NavigationService.Navigate(typeof(FormaPonudaPopust));
                    break;
                case 3:
                    NavigationService.Navigate(typeof(FormaNadjiLokaciju),true);
                    break;
                case 4:
                    NavigationService.Navigate(typeof(FormaPomocIKontakt));
                    break;
                case 5:
                    NavigationService.Navigate(typeof(FormaInformacije));
                    break;
                case 6:
                    NavigationService.Navigate(typeof(FormaPostavke));
                    break;                
            }
        }

        public ObservableCollection<MenuItem> OsnovniMenuItemi { get; set; }




        public event PropertyChangedEventHandler PropertyChanged;

        private MainPageViewModel() {
            OsnovniMenuItemi = new ObservableCollection<MenuItem>();
            OsnovniMenuItemi.Add(new MenuItem { Icon = "\uE804", Text = "Rezervacije", Tag = 0 });
            OsnovniMenuItemi.Add(new MenuItem { Icon = "\uE77B", Text = "Moj račun", Tag = 1 });
            OsnovniMenuItemi.Add(new MenuItem { Icon = "\uE94C", Text = "Najbolje ponude", Tag = 2 });
            OsnovniMenuItemi.Add(new MenuItem { Icon = "\uE1C4", Text = "Pronađi stanice", Tag = 3 });
            OsnovniMenuItemi.Add(new MenuItem { Icon = "\uE11B", Text = "Pomoć", Tag = 4 });
            OsnovniMenuItemi.Add(new MenuItem { Icon = "\uE946", Text = "Informacije", Tag = 5 });
            OsnovniMenuItemi.Add(new MenuItem { Icon = "\uE115", Text = "Postavke", Tag = 6 });


            selectedItem = OsnovniMenuItemi.ElementAt(0);
            NavigationService = new Helper.NavigationService();
            NavigationService.Navigate(typeof(FormaOdabirLokacijeIDatuma));
        }

        private static MainPageViewModel instance;
        public static MainPageViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainPageViewModel();
                }
                return instance;
            }
        }

        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }

        public void changeSelectedItemTo(int tag)
        {
            SelectedItem = OsnovniMenuItemi.ElementAt(tag);
        }
    }
}

