using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatRentACar.Models
{
    class DefaultPodaci
    {
        public static void Initialize(InformacijeDBContext context, ONamaDbContext context1, PostavkeDbContext context2)
        {
            if (!context.Informacije.Any())
            {
                context.Informacije.AddRange(
                new Informacije()
                {
                    ONama = "Lavoviiiii",
                    Privatnost = "Privatnost",
                    UsloviKoristenja = "Uslovi koristenja",
                }
                );
                context.SaveChanges();
            }
            if (!context1.NasiPodaci.Any())
            {
                context1.NasiPodaci.AddRange(
                new ONama()
                {
                    Ime = "Rent A Car",
                    Adresa = "Zmaja od Bosne bb",
                    Sjediste = "Franca Lehara 2, Sarajevo",
                    Copyright = "Sva prava zadržana",
                    VerzijaAplikacije = "1.0.0(0)",
                }
                );
                context1.SaveChanges();
            }
            if (!context2.postavke.Any())
            {
                context2.postavke.AddRange(
                new Postavke()
                {
                    Valuta = "Bosna i Hercegovina - Konvertibilna marka",
                    Lokacija = false,
                    Notifikacije = true,
                }
                );
                context2.SaveChanges();
            }
        }


    }
}
