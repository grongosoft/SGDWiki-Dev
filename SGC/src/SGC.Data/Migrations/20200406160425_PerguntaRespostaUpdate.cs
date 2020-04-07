using Microsoft.EntityFrameworkCore.Migrations;

namespace SGC.Data.Migrations
{
    public partial class PerguntaRespostaUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Perguntas",
                newName: "OperadorId");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Respostas",
                type: "nvarchar(4000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10000)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperadorId",
                table: "Perguntas",
                newName: "UsuarioId");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Respostas",
                type: "nvarchar(10000)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4000)");
        }
    }
}
