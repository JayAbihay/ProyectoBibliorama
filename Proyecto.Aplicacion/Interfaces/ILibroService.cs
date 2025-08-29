using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Entidades.DTOs;

namespace Proyecto.Aplicacion.Interfaces
{
    public interface ILibroService
    {
        Task<bool> ActualizarLibroModelAsync(LibrosModel libro);
        LibrosDTO ConvertToDTO(LibrosModel model);
        LibrosModel ConvertToModel(LibrosDTO dto);
        Task<LibrosModel> CrearLibroAsync(LibrosModel libros);
        Task<bool> EliminarLibroAsync(int id);
        Task<LibrosModel> ObtenerLibroPorIdAsync(int id);
        Task<List<LibrosModel>> ObtenerListadoLibrosAsync();
    }
}
