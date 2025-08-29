using System.ComponentModel.DataAnnotations;

namespace Proyecto.Dominio.Entidades
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]

        public string Nombre { get; set; }
        [Required(ErrorMessage = "Este campo es requerido.")]
        [StringLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres.")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
