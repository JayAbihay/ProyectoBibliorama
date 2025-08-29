using Proyecto.Dominio.Entidades.Enums;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Dominio.Entidades
{
    public class InformacionEmpresaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Nombre de la Empresa")]
        public string NombreEmpresa { get; set; }
        public EstadoNombreEnum EstadoNombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Dirección de la Empresa")]
        public string Direccion { get; set; }
        public EstadoDireccionEnum EstadoDireccion { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Descripción de la Empresa")]
        public string Descripcion { get; set; }
        public EstadoGeneralEnum EstadoDescripcion { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Número de télefono")]
        public string Telefono { get; set; }
        public EstadoGeneralEnum EstadoTelefono { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }
        public EstadoGeneralEnum EstadoCorreoElectronico { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Display(Name = "Identificación Fiscal")]
        public string Identificacion { get; set; }
        public EstadoGeneralEnum EstadoIdentificacion { get; set; }
        public string LogoImagePath { get; set; }
        public EstadoGeneralEnum EstadoLogo { get; set; }
        public string CarouselImage1Path { get; set; }
        public EstadoGeneralEnum CarouselImage1PathEstado { get; set; }
        public string CarouselImage2Path { get; set; }
        public EstadoGeneralEnum CarouselImage2PathEstado { get; set; }
        public string CarouselImage3Path { get; set; }
        public EstadoGeneralEnum CarouselImage3PathEstado { get; set; }
        public string DescripcionCarousel1 { get; set; }
        public EstadoGeneralEnum DescripcionCarousel1Estado { get; set; }
        public string DescripcionCarousel2 { get; set; }
        public EstadoGeneralEnum DescripcionCarousel2Estado { get; set; }
        public string DescripcionCarousel3 { get; set; }
        public EstadoGeneralEnum DescripcionCarousel3Estado { get; set; }


    }
}
