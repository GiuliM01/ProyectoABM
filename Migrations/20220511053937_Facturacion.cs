using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoABM.Migrations
{
    public partial class Facturacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Facturaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Precio",
                table: "Facturaciones",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Facturaciones");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Facturaciones");
        }
    }
}
