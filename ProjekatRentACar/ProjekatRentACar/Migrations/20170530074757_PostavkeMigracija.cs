using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ProjekatRentACarMigrations
{
    public partial class PostavkeMigracija : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Postavke",
                columns: table => new
                {
                    PostavkeId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    Lokacija = table.Column(type: "INTEGER", nullable: false),
                    Notifikacije = table.Column(type: "INTEGER", nullable: false),
                    Valuta = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postavke", x => x.PostavkeId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Postavke");
        }
    }
}
