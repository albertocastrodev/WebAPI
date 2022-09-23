using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbertoWebApi.Migrations
{
    public partial class criacaoentidadetelefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TelefoneId",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TelefonesId",
                table: "Pessoas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DDD = table.Column<int>(type: "int", nullable: false),
                    NumeroTEL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_TelefonesId",
                table: "Pessoas",
                column: "TelefonesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Telefones_TelefonesId",
                table: "Pessoas",
                column: "TelefonesId",
                principalTable: "Telefones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Telefones_TelefonesId",
                table: "Pessoas");

            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_TelefonesId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "TelefoneId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "TelefonesId",
                table: "Pessoas");
        }
    }
}
