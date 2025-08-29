using Microsoft.EntityFrameworkCore;
using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Interfaces;
using Proyecto.Infraestructura.Data;

namespace Proyecto.Infraestructura.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _dbcontext;

        public CategoriaRepositorio(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        // INDEX 
        public async Task<List<CategoriaModel>> ObtenerListadoCategoria()
        {
            return await _dbcontext.Categorias.ToListAsync();
        }

        // OBTENER POR ID 

        public async Task<CategoriaModel> ObtenerCategoriaPorId(int id)
        {
            return await _dbcontext.Categorias.FindAsync(id);
        }

        // CREAR 

        public async Task CrearCategoria(CategoriaModel categoria)
        {
            await _dbcontext.Categorias.AddAsync(categoria);
            await _dbcontext.SaveChangesAsync();
        }

        // EDITAR

        public async Task ActualizarCategoria(CategoriaModel categoria)
        {
            var categoriaAnterior = await ObtenerCategoriaPorId(categoria.Id);

            if (categoriaAnterior != null)
            {
                categoriaAnterior.Nombre = categoria.Nombre;
                categoriaAnterior.Descripcion = categoria.Descripcion;
                await _dbcontext.SaveChangesAsync();
            }
        }

        // ELIMINAR 

        public async Task EliminarCategoria (int id)
        {
            var categoria = await ObtenerCategoriaPorId(id);

            if (categoria != null)
            {
                _dbcontext.Categorias.Remove(categoria);
                await _dbcontext.SaveChangesAsync();
            }
        }




    }
}
