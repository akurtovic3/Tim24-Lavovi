using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ProjekatRentACar.Models;

namespace ProjekatRentACarMigrations
{
    [ContextType(typeof(PostavkeDbContext))]
    partial class PostavkeMigracija
    {
        public override string Id
        {
            get { return "20170530074757_PostavkeMigracija"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("ProjekatRentACar.Models.Postavke", b =>
                {
                    b.Property<int>("PostavkeId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Lokacija");

                    b.Property<bool>("Notifikacije");

                    b.Property<string>("Valuta");

                    b.Key("PostavkeId");
                });
        }
    }
}
