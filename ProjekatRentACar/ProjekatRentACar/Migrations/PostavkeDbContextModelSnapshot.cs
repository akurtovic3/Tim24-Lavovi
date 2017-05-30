using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ProjekatRentACar.Models;

namespace ProjekatRentACarMigrations
{
    [ContextType(typeof(PostavkeDbContext))]
    partial class PostavkeDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
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
