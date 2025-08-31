using Proyecto.Dominio.Interfaces;
using Proyecto.Infraestructura.Data;

namespace Proyecto.Infraestructura.Repositorios
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbcontext;

        public UnitOfWork(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task GuardarAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }

    }
}
