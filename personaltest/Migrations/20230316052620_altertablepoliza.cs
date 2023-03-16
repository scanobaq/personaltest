using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personaltest.Migrations
{
    public partial class altertablepoliza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NumeroPoliza",
                table: "Polizas",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Polizas",
                newName: "NumeroPoliza");
        }
    }
}
