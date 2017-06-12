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
using Prism.Windows.Validation;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ProjekatRentACar.ViewModels
{
    class UnosNovogVozilaViewModel : ValidatableBindableBase, INotifyPropertyChanged
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

        public ObservableCollection<string> erori { get; set; }

        private TipVozila tip;
        [Required]
        public TipVozila Tip { get { return tip; } set { SetProperty(ref tip, value); } }

        private string model;
        [Required]
        public string Model { get { return model; } set { SetProperty(ref model, value); } }

        private string proizvodjac;
        [Required]
        public string Proizvodjac { get { return proizvodjac; } set { SetProperty(ref proizvodjac, value); } }

        private VrstaGoriva vrstaGoriva;
        [Required]
        public VrstaGoriva VrstaGoriva { get { return vrstaGoriva; } set { SetProperty(ref vrstaGoriva, value); } }

        private string snaga;
        [Required]
        public string Snaga { get { return snaga; } set { SetProperty(ref snaga, value); } }

        private string kilometraza;
        [Required]
        public string Kilometraza { get { return kilometraza; } set { SetProperty(ref kilometraza, value); } }

        private string brojSjedista;
        [Required]
        public string BrojSjedista { get { return brojSjedista; } set { SetProperty(ref brojSjedista, value); } }

        private string brojVrata;
        [Required]
        public string BrojVrata { get { return brojVrata; } set { SetProperty(ref brojVrata, value); } }

        private string godiste;
        [Required]
        public string Godiste { get { return godiste; } set { SetProperty(ref godiste, value); } }

        private bool klima;
        [Required]
        public bool Klima { get { return klima; } set { SetProperty(ref klima, value); } }

        private bool navigacija;
        [Required]
        public bool Navigacija { get { return navigacija; } set { SetProperty(ref navigacija, value); } }

        private Mjenjac vrstaMjenjaca;
        [Required]
        public Mjenjac VrstaMjenjaca { get { return vrstaMjenjaca; } set { SetProperty(ref vrstaMjenjaca, value); } }

        private int zapreminaPrtljaznika;
        [Required]
        public int ZapreminaPrtljaznika { get { return zapreminaPrtljaznika; } set { SetProperty(ref zapreminaPrtljaznika, value); } }

        private string kubikaza;
        [Required]
        public string Kubikaza { get { return kubikaza; } set { SetProperty(ref kubikaza, value); } }

        private string popust;
        [Required]
        public string Popust { get { return popust; } set { SetProperty(ref popust, value); } }

        private string cijenaPoDanu;
        [Required]
        public string CijenaPoDanu { get { return cijenaPoDanu; } set { SetProperty(ref cijenaPoDanu, value); } }

        private double cijenaSaPopustom;
        [Required]
        public double CijenaSaPopustom { get { return cijenaSaPopustom; } set { SetProperty(ref cijenaSaPopustom, value); } }

        private BitmapImage slika;
        [Required]
        public BitmapImage Slika
        {
            get { return slika; }
            set
            {
                SetProperty(ref slika, value);
                OnNotifyPropertyChanged("Slika");
            }
        }

        private UploadVozilaDataSource uploadDS;

        private byte[] byteArray;

        public UnosNovogVozilaViewModel()
        {
            novoVozilo = new Vozilo();
            UnesiVozilo = new RelayCommand<object>(unosVozila);
            DodajSliku = new RelayCommand<object>(dodavanjeSlike);
            uploadDS = new UploadVozilaDataSource();
        }

        public async void unosVozila(object parameter)
        {

            //Treba prvo ispitati validaciju, pa ako prođe validacija, tek onda pokrenuti ovaj kod ispod...

            this.ValidateProperties();
            erori = new ObservableCollection<string>(Errors.Errors.Values.SelectMany(x => x).ToList());

            if ((erori == null || erori.Count == 0))
            {
                NovoVozilo.Tip = Tip;
                NovoVozilo.Proizvodjac = Proizvodjac;
                NovoVozilo.Model = Model;
                NovoVozilo.VrstaGoriva = VrstaGoriva;
                NovoVozilo.BrojSjedista = Convert.ToInt32(BrojSjedista);
                NovoVozilo.BrojVrata = Convert.ToInt32(BrojVrata);
                NovoVozilo.VrstaMjenjaca = VrstaMjenjaca;
                NovoVozilo.Klima = Klima;
                NovoVozilo.Navigacija = Navigacija;
                NovoVozilo.ZapreminaPrtljaznika = 4500;
                NovoVozilo.Snaga = Convert.ToInt32(Snaga);
                NovoVozilo.Kilometraza = Convert.ToInt32(Kilometraza);
                NovoVozilo.Godiste = Convert.ToInt32(Godiste);
                NovoVozilo.Popust = Convert.ToInt32(Popust);
                NovoVozilo.Kubikaza = Convert.ToDouble(Kubikaza);
                NovoVozilo.CijenaPoDanu = Convert.ToDouble(CijenaPoDanu);
                NovoVozilo.CijenaSaPopustom = NovoVozilo.CijenaPoDanu - (NovoVozilo.CijenaPoDanu * NovoVozilo.Popust / 100);

                uploadDS.unesiVozilo(novoVozilo, byteArray, callback).GetAwaiter();

                var msd = new MessageDialog("Uspješno ste unijeli novo vozilo");
                await msd.ShowAsync();
            }           
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
