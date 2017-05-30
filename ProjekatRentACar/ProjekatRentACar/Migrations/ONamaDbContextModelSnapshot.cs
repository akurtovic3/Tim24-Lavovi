using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ProjekatRentACar.Models;

namespace ProjekatRentACarMigrations
{
    [ContextType(typeof(ONamaDbContext))]
    partial class ONamaDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
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
