using Microsoft.EntityFrameworkCore.Migrations;

namespace SGC.Data.Migrations
{
    public partial class PerguntaRespostaUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OperadorId",
                table: "Perguntas",
                nullable: false,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "OperadorId",
                table: "Perguntas",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
