using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlbertoWebApi.Migrations
{
    public partial class AlteracoesPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Endereco_EnderecoId",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Telefones_TelefonesId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_TelefonesId",
                table: "Pessoas");

            migrationBuilder.RenameColumn(
                name: "NumeroTEL",
                table: "Telefones",
                newName: "Numero");

            migrationBuilder.AlterColumn<int>(
                name: "Tipo",
                table: "Telefones",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Telefones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_PessoaId",
                table: "Telefones",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PessoaId",
                table: "Endereco",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Pessoas_PessoaId",
                table: "Endereco",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Pessoas_PessoaId",
                table: "Telefones",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Pessoas_PessoaId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Pessoas_PessoaId",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_PessoaId",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_PessoaId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Telefones");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Endereco");

            migrationBuilder.RenameColumn(
                name: "Numero",
                table: "Telefones",
                newName: "NumeroTEL");

            migrationBuilder.AlterColumn<string>(
                name: "Tipo",
                table: "Telefones",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_TelefonesId",
                table: "Pessoas",
                column: "TelefonesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Endereco_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Telefones_TelefonesId",
                table: "Pessoas",
                column: "TelefonesId",
                principalTable: "Telefones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
