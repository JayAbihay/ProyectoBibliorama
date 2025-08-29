using Microsoft.EntityFrameworkCore;
using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Interfaces;
using Proyecto.Infraestructura.Data;

namespace Proyecto.Infraestructura.Repositorios
{
    public class InformacionEmpresaRepositorio : IInformacionEmpresaRepositorio
    {
        private readonly ApplicationDbContext _dbContext; 
        public InformacionEmpresaRepositorio(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<InformacionEmpresaModel>> ObtenerListadoInformacionEmpresa()
        {
            return await _dbContext.InformacionEmpresa.ToListAsync();
        }

        public async Task<InformacionEmpresaModel> ObtenerInformacionEmpresaPorId(int id)
        {
            return await _dbContext.InformacionEmpresa.FindAsync(id);
        }

        public async Task CrearInformacionEmpresa(InformacionEmpresaModel infoEmpresa)
        {
            await _dbContext.InformacionEmpresa.AddAsync(infoEmpresa);
            await _dbContext.SaveChangesAsync();
        }
    }
}
