using AutoMapper;
using Proyecto.Aplicacion.Interfaces;
using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Entidades.DTOs;
using Proyecto.Dominio.Interfaces;

namespace Proyecto.Aplicacion.Servicios
{
    public class LibroService : ILibroService
    {
        private readonly ILibrosRepositorio _libroRepositorio;
        private readonly IMapper _mapper;
        public LibroService(ILibrosRepositorio librosRepositorio, IMapper mapper)
        {
            _libroRepositorio = librosRepositorio;
            _mapper = mapper;
        }

        public LibrosModel ConvertToModel(LibrosDTO dto)
        {
            return _mapper.Map<LibrosModel>(dto);
        }

        public LibrosDTO ConvertToDTO(LibrosModel model)
        {
            return _mapper.Map<LibrosDTO>(model);
        }

        public async Task<List<LibrosModel>> ObtenerListadoLibrosAsync()
        {
            var listadoLibros = await _libroRepositorio.ObtenerListadoDeLibros();
            return listadoLibros;
        }

        public async Task<LibrosModel> ObtenerLibroPorIdAsync(int id)
        {
            var libroId = await _libroRepositorio.ObtenerLibroPorId(id);
            return libroId;
        }

        public async Task<LibrosModel> CrearLibroAsync(LibrosModel libros)
        {
            await _libroRepositorio.CrearLibro(libros);
            var libroId = libros.Id;
            var libroCreado = await ObtenerLibroPorIdAsync(libroId);
            return libroCreado;
        }

        public async Task<bool> ActualizarLibroModelAsync(LibrosModel libro)
        {
            var libroId = await ObtenerLibroPorIdAsync(libro.Id);

            if (libroId == null)
            {
                return false;
            }

            await _libroRepositorio.ActualizarLibro(libro);
            return true;
        }

        public async Task<bool> EliminarLibroAsync(int id)
        {
            var libroId = await ObtenerLibroPorIdAsync(id);

            if (libroId == null)
            {
                return false;
            }

            await _libroRepositorio.EliminarLibro(id);
            return true;
        }


    }
}
