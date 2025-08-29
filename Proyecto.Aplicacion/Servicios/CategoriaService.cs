using AutoMapper;
using Proyecto.Aplicacion.Interfaces;
using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Entidades.DTOs;
using Proyecto.Dominio.Interfaces;

namespace Proyecto.Aplicacion.Servicios
{
    public class CategoriaService : ICategoriaService
    {

        private readonly IMapper _mapper;
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaService(ICategoriaRepositorio categoriaRepositorio, IMapper mapper)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _mapper = mapper;

        }

        public CategoriaModel ConvertToModel(CategoriaDTO dto)
        {
            return _mapper.Map<CategoriaModel>(dto);
        }

        public CategoriaDTO ConvertToDTO(CategoriaModel model)
        {
            return _mapper.Map<CategoriaDTO>(model);
        }

        // Método de servicio para obtener un listado de los suministradores

        public async Task<List<CategoriaModel>> ObtenerListadoDeCategoriasAsync()
        {
            var listadoCategorias = await _categoriaRepositorio.ObtenerListadoCategoria();
            return listadoCategorias;
        }

        // Obtener por ID 

        public async Task<CategoriaModel> ObtenerCategoriaPorIdAsync(int id)
        {
            var categoria = await _categoriaRepositorio.ObtenerCategoriaPorId(id);
            return categoria;
        }


        public async Task<CategoriaModel> CrearCategoriaAsync(CategoriaModel categoria)
        {
            await _categoriaRepositorio.CrearCategoria(categoria);
            var categoriaId = categoria.Id;
            var categoriaCreada = await ObtenerCategoriaPorIdAsync(categoriaId);
            return categoriaCreada;
        }


        public async Task<bool> ActualizarCategoriaModelAsync(CategoriaModel categoria)
        {
            var categoriaId = await ObtenerCategoriaPorIdAsync(categoria.Id);

            if (categoriaId == null)
            {
                return false; 
            }

            await _categoriaRepositorio.ActualizarCategoria(categoria);
            return true;
        }

        public async Task<bool> EliminarCategoriaAsync(int id)
        {
            var categoria = await ObtenerCategoriaPorIdAsync(id);

            if (categoria == null)
            {
                return false;
            }

            await _categoriaRepositorio.EliminarCategoria(id);
            return true;
        }
    }
}
