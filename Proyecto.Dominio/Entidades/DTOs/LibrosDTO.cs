namespace Proyecto.Dominio.Entidades.DTOs
{
    public class LibrosDTO
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public float Cantidad { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaModel Categoria { get; set; }
        public IEnumerable<CategoriaModel> CategoriasList { get; set; } = new List<CategoriaModel>();
    }
}
