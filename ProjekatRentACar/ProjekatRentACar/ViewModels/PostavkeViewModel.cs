using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ProjekatRentACar.Models;

namespace ProjekatRentACar.ViewModels
{
    class PostavkeViewModel : INotifyPropertyChanged
    {
        private string valuta;

        public string Valuta
        {
            get { return valuta; }
            set { valuta = value; }
        }


        private bool notifikacija;

        public bool Notifikacija
        {
            get { return notifikacija; }
            set
            {
                notifikacija = value;
                OnNotifyPropertyChanged("Notifikacija");
                using (var db = new PostavkeDbContext())
                {
                    var r = db.postavke.SingleOrDefault(b => b.PostavkeId == 1);
                    if(r != null)
                    {
                        r.Notifikacije = notifikacija; // update
                        db.SaveChanges();
                    }                 
                }
            }
        }

        private bool lokacija;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool Lokacija
        {
            get { return lokacija; }
            set
            {
                lokacija = value;
                OnNotifyPropertyChanged("Lokacija");
                using (var db = new PostavkeDbContext())
                {
                    var r = db.postavke.SingleOrDefault(b => b.PostavkeId == 1);
                    if (r != null)
                    {
                        r.Lokacija = lokacija; // update
                        db.SaveChanges();
                    }
                }
            }
        }

        public PostavkeViewModel()
        {
            using (var db = new PostavkeDbContext())
            {
                // read
                Valuta = db.postavke.Select(x => x.Valuta).ToList<string>().ElementAt(0);
                Lokacija = db.postavke.Select(x => x.Lokacija).ToList<bool>().ElementAt(0);
                Notifikacija = db.postavke.Select(x => x.Notifikacije).ToList<bool>().ElementAt(0);
            }
        }

        protected void OnNotifyPropertyChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
