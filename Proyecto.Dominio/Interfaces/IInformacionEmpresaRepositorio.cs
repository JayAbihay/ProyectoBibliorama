using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Entidades.Enums;

namespace Proyecto.Dominio.Interfaces
{
    public interface IInformacionEmpresaRepositorio
    {
        Task CambiarEstadoCarouselImage1(int id, EstadoGeneralEnum estadoCarouselImage1);
        Task CambiarEstadoCarouselImage2(int id, EstadoGeneralEnum estadoCarouselImage2);
        Task CambiarEstadoCarouselImage3(int id, EstadoGeneralEnum estadoCarouselImage3);
        Task CambiarEstadoCorreoElectronico(int id, EstadoGeneralEnum estadoCorreoElectronico);
        Task CambiarEstadoDescripcion(int id, EstadoGeneralEnum estadoDescripcion);
        Task CambiarEstadoDescripcionCarousel1(int id, EstadoGeneralEnum estadoDescripcionCarousel1);
        Task CambiarEstadoDescripcionCarousel2(int id, EstadoGeneralEnum estadoDescripcionCarousel2);
        Task CambiarEstadoDescripcionCarousel3(int id, EstadoGeneralEnum estadoDescripcionCarousel3);
        Task CambiarEstadoDireccion(int id, EstadoDireccionEnum estadoDireccion);
        Task CambiarEstadoIdentificacion(int id, EstadoGeneralEnum estadoIdentificacion);
        Task CambiarEstadoLogo(int id, EstadoGeneralEnum estadoLogo);
        Task CambiarEstadoNombre(int id, EstadoNombreEnum estadoNombre);
        Task CambiarEstadoTelefono(int id, EstadoGeneralEnum estadoTelefono);
        Task CrearInformacionEmpresa(InformacionEmpresaModel infoEmpresa);
        Task<InformacionEmpresaModel> ObtenerInformacionEmpresaPorId(int id);
        Task<List<InformacionEmpresaModel>> ObtenerListadoInformacionEmpresa();
    }
}
