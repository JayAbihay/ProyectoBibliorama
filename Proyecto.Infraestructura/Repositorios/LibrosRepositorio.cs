using Microsoft.EntityFrameworkCore;
using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Interfaces;
using Proyecto.Infraestructura.Data;

namespace Proyecto.Infraestructura.Repositorios
{
    public class LibrosRepositorio : ILibrosRepositorio
    {
        private readonly ApplicationDbContext _dbcontext;
        public LibrosRepositorio(ApplicationDbContext dbContext) 
        {
            _dbcontext = dbContext;
        }

        public async Task<List<LibrosModel>> ObtenerListadoDeLibros()
        {
            return await _dbcontext.Libros.Include(c => c.Categoria).ToListAsync();
        }

        public async Task<LibrosModel> ObtenerLibroPorId(int id)
        {
            return await _dbcontext.Libros.FindAsync(id);
        }

        // CREAR 

        public async Task CrearLibro(LibrosModel libros)
        {
            await _dbcontext.Libros.AddAsync(libros);
            await _dbcontext.SaveChangesAsync();
        }
        
        public async Task ActualizarLibro(LibrosModel libros)
        {
            var libroAnterior = await ObtenerLibroPorId(libros.Id);

            if (libroAnterior != null)
            {
                libroAnterior.ISBN = libros.ISBN;
                libroAnterior.Titulo = libros.Titulo;
                libroAnterior.Autor = libros.Autor;
                libroAnterior.CategoriaId = libros.CategoriaId;
                libroAnterior.Descripcion = libros.Descripcion;
                libroAnterior.Categoria = libros.Categoria;
                libroAnterior.Cantidad = libros.Cantidad;
                libroAnterior.Precio = libros.Precio;
                libroAnterior.FechaPublicacion = libros.FechaPublicacion;
                libroAnterior.ImagePath = libros.ImagePath;
                await _dbcontext.SaveChangesAsync();
            }
        }

        public async Task EliminarLibro(int id)
        {
            var libro = await ObtenerLibroPorId(id);

            if (libro != null)
            {
                _dbcontext.Libros.Remove(libro);
                await _dbcontext.SaveChangesAsync();
            }
        }


    }
}
