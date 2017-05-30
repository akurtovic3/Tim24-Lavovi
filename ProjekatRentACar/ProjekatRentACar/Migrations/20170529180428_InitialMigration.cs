using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ProjekatRentACarMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Informacije",
                columns: table => new
                {
                    informacijeID = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true.ToString()),
                    ONama = table.Column(type: "TEXT", nullable: true),
                    Privatnost = table.Column(type: "TEXT", nullable: true),
                    UsloviKoristenja = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informacije", x => x.informacijeID);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Informacije");
        }
    }
}
