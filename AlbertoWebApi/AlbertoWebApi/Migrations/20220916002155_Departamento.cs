using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbertoWebApi.Migrations
{
    public partial class Departamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Pessoas");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_DepartamentoId",
                table: "Pessoas",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Departamentos_DepartamentoId",
                table: "Pessoas",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Departamentos_DepartamentoId",
                table: "Pessoas");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_DepartamentoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "Pessoas");

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
