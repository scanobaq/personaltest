using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace personaltest.Migrations
{
    public partial class altertablepolizaup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NumeroPoliza",
                table: "Polizas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroPoliza",
                table: "Polizas");
        }
    }
}
