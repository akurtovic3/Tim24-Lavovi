using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjekatRentACar.Models;
using ProjekatRentACar.Helper;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using ProjekatRentACar.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProjekatRentACar.ViewModels
{
    class UnosNovogVozilaViewModel : INotifyPropertyChanged
    {
        private Vozilo novoVozilo;

        public event PropertyChangedEventHandler PropertyChanged;

        public Vozilo NovoVozilo
        {
            get { return novoVozilo; }
            set { novoVozilo = value; }
        }

        public ICommand UnesiVozilo { get; set; }
        public ICommand DodajSliku { get; set; }

        private BitmapImage slika;
        public BitmapImage Slika
        {
            get { return slika; }
            set
            {
                slika = value;
                OnNotifyPropertyChanged("Slika");
            }
        }

        public UnosNovogVozilaViewModel()
        {
            novoVozilo = new Vozilo();
            UnesiVozilo = new RelayCommand<object>(unosVozila);
            DodajSliku = new RelayCommand<object>(dodavanjeSlike);
        }

        public void unosVozila(object parameter)
        {
            MessageDialog msd = new MessageDialog("Uspješno ste unijeli novo vozilo");
            msd.ShowAsync();
        }

        public async void dodavanjeSlike(object parameter)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();
            if (file != null)
            {
                // Application now has read/write access to the picked file
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                Slika = new BitmapImage();
                Slika.SetSource(stream);
                
            }
            else
            {
                MessageDialog msd = new MessageDialog("Učitavanje slike nije uspjelo");
                msd.ShowAsync();
            }
        }

        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
