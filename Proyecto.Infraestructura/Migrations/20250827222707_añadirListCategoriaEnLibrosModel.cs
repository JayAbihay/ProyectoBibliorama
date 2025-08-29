using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Infraestructura.Migrations
{
    public partial class añadirListCategoriaEnLibrosModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibrosModelId",
                table: "Categorias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_LibrosModelId",
                table: "Categorias",
                column: "LibrosModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Libros_LibrosModelId",
                table: "Categorias",
                column: "LibrosModelId",
                principalTable: "Libros",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Libros_LibrosModelId",
                table: "Categorias");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_LibrosModelId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "LibrosModelId",
                table: "Categorias");
        }
    }
}
