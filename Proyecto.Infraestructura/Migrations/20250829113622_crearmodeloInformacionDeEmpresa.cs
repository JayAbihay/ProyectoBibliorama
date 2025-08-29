using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyecto.Infraestructura.Migrations
{
    public partial class crearmodeloInformacionDeEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "InformacionEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoNombre = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoDireccion = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoDescripcion = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoTelefono = table.Column<int>(type: "int", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoCorreoElectronico = table.Column<int>(type: "int", nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoIdentificacion = table.Column<int>(type: "int", nullable: false),
                    LogoImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoLogo = table.Column<int>(type: "int", nullable: false),
                    CarouselImage1Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarouselImage1PathEstado = table.Column<int>(type: "int", nullable: false),
                    CarouselImage2Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarouselImage2PathEstado = table.Column<int>(type: "int", nullable: false),
                    CarouselImage3Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarouselImage3PathEstado = table.Column<int>(type: "int", nullable: false),
                    DescripcionCarousel1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionCarousel1Estado = table.Column<int>(type: "int", nullable: false),
                    DescripcionCarousel2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionCarousel2Estado = table.Column<int>(type: "int", nullable: false),
                    DescripcionCarousel3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescripcionCarousel3Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionEmpresa", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InformacionEmpresa");

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
