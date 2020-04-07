using Microsoft.EntityFrameworkCore.Migrations;

namespace SGC.Data.Migrations
{
    public partial class PerguntaRespostaUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perguntas_Categorias_CategoriaId",
                table: "Perguntas");

            migrationBuilder.DropIndex(
                name: "IX_Perguntas_CategoriaId",
                table: "Perguntas");

            migrationBuilder.AlterColumn<long>(
                name: "CategoriaId",
                table: "Perguntas",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CategoriaId",
                table: "Perguntas",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_CategoriaId",
                table: "Perguntas",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perguntas_Categorias_CategoriaId",
                table: "Perguntas",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
