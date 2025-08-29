using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Entidades.DTOs;

namespace Proyecto.Aplicacion.Interfaces
{
    public interface ICategoriaService
    {
        Task<bool> ActualizarCategoriaModelAsync(CategoriaModel categoria);
        CategoriaDTO ConvertToDTO(CategoriaModel model);
        CategoriaModel ConvertToModel(CategoriaDTO dto);
        Task<CategoriaModel> CrearCategoriaAsync(CategoriaModel categoria);
        Task<bool> EliminarCategoriaAsync(int id);
        Task<CategoriaModel> ObtenerCategoriaPorIdAsync(int id);
        Task<List<CategoriaModel>> ObtenerListadoDeCategoriasAsync();
    }
}
