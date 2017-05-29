using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ProjekatRentACar.Models;

namespace ProjekatRentACarMigrations
{
    [ContextType(typeof(InformacijeDBContext))]
    partial class InformacijeDBContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("ProjekatRentACar.Models.Informacije", b =>
                {
                    b.Property<int>("informacijeID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ONama");

                    b.Property<string>("Privatnost");

                    b.Property<string>("UsloviKoristenja");

                    b.Key("informacijeID");
                });
        }
    }
}
