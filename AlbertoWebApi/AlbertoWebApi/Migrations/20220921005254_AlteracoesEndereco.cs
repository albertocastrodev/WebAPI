using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbertoWebApi.Migrations
{
    public partial class AlteracoesEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "logradouro",
                table: "Endereco",
                newName: "Logradouro");

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Logradouro",
                table: "Endereco",
                newName: "logradouro");

            migrationBuilder.AlterColumn<int>(
                name: "Numero",
                table: "Endereco",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "logradouro",
                table: "Endereco",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
