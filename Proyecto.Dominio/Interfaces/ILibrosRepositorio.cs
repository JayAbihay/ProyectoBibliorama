using Proyecto.Dominio.Entidades;

namespace Proyecto.Dominio.Interfaces
{
    public interface ILibrosRepositorio
    {
        Task ActualizarLibro(LibrosModel libros);
        Task CrearLibro(LibrosModel libros);
        Task EliminarLibro(int id);
        Task<LibrosModel> ObtenerLibroPorId(int id);
        Task<List<LibrosModel>> ObtenerListadoDeLibros();
    }
}
