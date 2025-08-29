using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Dominio.Entidades
{
    public class LibrosModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(13, ErrorMessage = "El campo {0} requiere menos de 13 caracteres")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(50, ErrorMessage = "El campo {0} requiere menos de 50 caracteres")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [StringLength(255, ErrorMessage = "El campo {0} requiere menos de 255 caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(0.01, 10000.00, ErrorMessage = "El campo {0} debe estar entre {1} y {2}")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Range(0, 1000, ErrorMessage = "El campo {0} debe estar entre {1} y {2}")]
        public float Cantidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fecha de Publicación")]
        public DateTime FechaPublicacion { get; set; }
        [Display(Name = "Categoría")]
        public int CategoriaId { get; set; }
        [ValidateNever]
        public IEnumerable<CategoriaModel> CategoriasList { get; set; } = new List<CategoriaModel>();
        [ValidateNever]
        public CategoriaModel Categoria { get; set; } 
        public string? ImagePath { get; set; }

    }
}
