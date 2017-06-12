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
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ProjekatRentACar.ViewModels
{
    class UnosNovogVozilaViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Vozilo novoVozilo;
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

        public string Snaga { get; set; }
        public string Kilometraza { get; set; }
        public string BrojSjedista { get; set; }
        public string BrojVrata { get; set; }
        public string Godiste { get; set; }
        public string Kubikaza { get; set; }
        public string Popust { get; set; }
        public string CijenaPoDanu { get; set; }
        private UploadVozilaDataSource uploadDS;

        private byte[] byteArray;

        public UnosNovogVozilaViewModel()
        {
            novoVozilo = new Vozilo();
            UnesiVozilo = new RelayCommand<object>(unosVozila);
            DodajSliku = new RelayCommand<object>(dodavanjeSlike);
            uploadDS = new UploadVozilaDataSource();
        }

        public  void unosVozila(object parameter)
        {

            //Treba prvo ispitati validaciju, pa ako prođe validacija, tek onda pokrenuti ovaj kod ispod...
            /*
            NovoVozilo.BrojSjedista = Convert.ToInt32(BrojSjedista);
            NovoVozilo.BrojVrata = Convert.ToInt32(BrojVrata);
            NovoVozilo.Snaga = Convert.ToInt32(Snaga);
            NovoVozilo.Kilometraza = Convert.ToInt32(Kilometraza);
            NovoVozilo.Godiste = Convert.ToInt32(Godiste);
            NovoVozilo.Popust = Convert.ToInt32(Popust);
            NovoVozilo.Kubikaza = Convert.ToDouble(Kubikaza);
            NovoVozilo.CijenaPoDanu = Convert.ToDouble(CijenaPoDanu);
         */
            uploadDS.unesiVozilo(novoVozilo, byteArray, callback).GetAwaiter();
        }




        private void callback()
        {
            showMessageBox();
        }

        private async void showMessageBox()
        {
            MessageDialog ms = new MessageDialog(uploadDS.ErrorText);
            await ms.ShowAsync();
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

                var dr = new DataReader(stream.GetInputStreamAt(0));
                byteArray = new byte[stream.Size];
                await dr.LoadAsync((uint)stream.Size);
                dr.ReadBytes(byteArray);
            }
            else
            {
                MessageDialog msd = new MessageDialog("Učitavanje slike nije uspjelo");
                await msd.ShowAsync();
            }
        }

        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }


       

    }
}
