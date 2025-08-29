using Proyecto.Dominio.Entidades;

namespace Proyecto.Dominio.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task ActualizarCategoria(CategoriaModel categoria);
        Task CrearCategoria(CategoriaModel categoria);
        Task EliminarCategoria(int id);
        Task<CategoriaModel> ObtenerCategoriaPorId(int id);
        Task<List<CategoriaModel>> ObtenerListadoCategoria();
    }
}
