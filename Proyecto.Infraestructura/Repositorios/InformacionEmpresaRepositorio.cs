using Microsoft.EntityFrameworkCore;
using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Entidades.Enums;
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

        public async Task CambiarEstadoNombre(int id, EstadoNombreEnum estadoNombre)
        {
            var infoEmpresa = await ObtenerInformacionEmpresaPorId(id);

            if (infoEmpresa != null)
            {
                infoEmpresa.EstadoNombre = estadoNombre;
                _dbContext.InformacionEmpresa.Update(infoEmpresa);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task CambiarEstadoDireccion(int id, EstadoDireccionEnum estadoDireccion)
        {
            var infoEmpresa = await ObtenerInformacionEmpresaPorId(id);

            if (infoEmpresa != null)
            {
                infoEmpresa.EstadoDireccion = estadoDireccion;
                _dbContext.InformacionEmpresa.Update(infoEmpresa);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task CambiarEstadoDescripcion(int id, EstadoGeneralEnum estadoDescripcion)
        {
            var infoEmpresa = await ObtenerInformacionEmpresaPorId(id);

            if (infoEmpresa != null)
            {
                infoEmpresa.EstadoDescripcion = estadoDescripcion;
                _dbContext.InformacionEmpresa.Update(infoEmpresa);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task CambiarEstadoTelefono(int id, EstadoGeneralEnum estadoTelefono)
        {
            var infoEmpresa = await ObtenerInformacionEmpresaPorId(id);

            if (infoEmpresa != null)
            {
                infoEmpresa.EstadoTelefono = estadoTelefono;
                _dbContext.InformacionEmpresa.Update(infoEmpresa);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task CambiarEstadoCorreoElectronico(int id, EstadoGeneralEnum estadoCorreoElectronico)
        {
            var infoEmpresa = await ObtenerInformacionEmpresaPorId(id);

            if (infoEmpresa != null)
            {
                infoEmpresa.EstadoCorreoElectronico = estadoCorreoElectronico;
                _dbContext.InformacionEmpresa.Update(infoEmpresa);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task CambiarEstadoIdentificacion(int id, EstadoGeneralEnum estadoIdentificacion)
        {
            var infoEmpresa = await ObtenerInformacionEmpresaPorId(id);

            if (infoEmpresa != null)
            {
                infoEmpresa.EstadoIdentificacion = estadoIdentificacion;
                _dbContext.InformacionEmpresa.Update(infoEmpresa);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task CambiarEstadoLogo(int id, EstadoGeneralEnum estadoLogo)
        {
            var infoEmpresa = await ObtenerInformacionEmpresaPorId(id);

            if (infoEmpresa != null)
            {
                infoEmpresa.EstadoLogo = estadoLogo;
                _dbContext.InformacionEmpresa.Update(infoEmpresa);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task CambiarEstadoCarouselImage1(int id, EstadoGeneralEnum estadoCarouselImage1)
        {
            var infoEmpresa = await ObtenerInformacionEmpresaPorId(id);

            if (infoEmpresa != null)
            {
                infoEmpresa.CarouselImage1PathEstado = estadoCarouselImage1;
                _dbContext.InformacionEmpresa.Update(infoEmpresa);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task CambiarEstadoCarouselImage2(int id, EstadoGeneralEnum estadoCarouselImage2)
        {
            var infoEmpresa = await ObtenerInformacionEmpresaPorId(id);

            if (infoEmpresa != null)
            {
                infoEmpresa.CarouselImage2PathEstado = estadoCarouselImage2;
                _dbContext.InformacionEmpresa.Update(infoEmpresa);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task CambiarEstadoCarouselImage3(int id, EstadoGeneralEnum estadoCarouselImage3)
        {
            var infoEmpresa = await ObtenerInformacionEmpresaPorId(id);

            if (infoEmpresa != null)
            {
                infoEmpresa.CarouselImage3PathEstado = estadoCarouselImage3;
                _dbContext.InformacionEmpresa.Update(infoEmpresa);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task CambiarEstadoDescripcionCarousel1(int id, EstadoGeneralEnum estadoDescripcionCarousel1)
        {
            var infoEmpresa = await ObtenerInformacionEmpresaPorId(id);

            if (infoEmpresa != null)
            {
                infoEmpresa.DescripcionCarousel1Estado = estadoDescripcionCarousel1;
                _dbContext.InformacionEmpresa.Update(infoEmpresa);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task CambiarEstadoDescripcionCarousel2(int id, EstadoGeneralEnum estadoDescripcionCarousel2)
        {
            var infoEmpresa = await ObtenerInformacionEmpresaPorId(id);

            if (infoEmpresa != null)
            {
                infoEmpresa.DescripcionCarousel2Estado = estadoDescripcionCarousel2;
                _dbContext.InformacionEmpresa.Update(infoEmpresa);
                await _dbContext.SaveChangesAsync();

            }
        }

        public async Task CambiarEstadoDescripcionCarousel3(int id, EstadoGeneralEnum estadoDescripcionCarousel3)
        {
            var infoEmpresa = await ObtenerInformacionEmpresaPorId(id);

            if (infoEmpresa != null)
            {
                infoEmpresa.DescripcionCarousel3Estado = estadoDescripcionCarousel3;
                _dbContext.InformacionEmpresa.Update(infoEmpresa);
                await _dbContext.SaveChangesAsync();

            }
        }


    }
}
