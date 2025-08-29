using Microsoft.EntityFrameworkCore;
using Proyecto.Dominio.Entidades;

namespace Proyecto.Infraestructura.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    :   base(options)
        {
        }

        public DbSet<CategoriaModel> Categorias { get; set; }
        public DbSet<LibrosModel> Libros { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
    }
}
