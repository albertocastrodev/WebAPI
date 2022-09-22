using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbertoWebApi.Migrations
{
    public partial class criacaoentidadetelefones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "Pessoas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
