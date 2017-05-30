using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ProjekatRentACar.Models;

namespace ProjekatRentACarMigrations
{
    [ContextType(typeof(ONamaDbContext))]
    partial class Migracija
    {
        public override string Id
        {
            get { return "20170530015327_Migracija"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("ProjekatRentACar.Models.ONama", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adresa");

                    b.Property<string>("Copyright");

                    b.Property<string>("Ime");

                    b.Property<string>("Sjediste");

                    b.Property<string>("VerzijaAplikacije");

                    b.Key("Id");
                });
        }
    }
}
