using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Entidades.DTOs;
using Proyecto.Dominio.Entidades.Enums;

namespace Proyecto.Aplicacion.Interfaces
{
    public interface IInformacionEmpresaService
    {
        Task CambiarEstadoCarouselImage1PathAsync(int id, EstadoGeneralEnum estadoCarouselImage1Path);
        Task CambiarEstadoCarouselImage2PathAsync(int id, EstadoGeneralEnum estadoCarouselImage2Path);
        Task CambiarEstadoCarouselImage3PathAsync(int id, EstadoGeneralEnum estadoCarouselImage3Path);
        Task CambiarEstadoCorreoElectronicoAsync(int id, EstadoGeneralEnum estadoCorreoElectronico);
        Task CambiarEstadoDescripcionAsync(int id, EstadoGeneralEnum estadoDescripcion);
        Task CambiarEstadoDescripcionCarousel1Async(int id, EstadoGeneralEnum estadoDescripcionCarousel1);
        Task CambiarEstadoDescripcionCarousel2Async(int id, EstadoGeneralEnum estadoDescripcionCarousel2);
        Task CambiarEstadoDescripcionCarousel3Async(int id, EstadoGeneralEnum estadoDescripcionCarousel3);
        Task CambiarEstadoDireccionAsync(int id, EstadoDireccionEnum estadoDireccion);
        Task CambiarEstadoIdentificacionAsync(int id, EstadoGeneralEnum estadoIdentificacion);
        Task CambiarEstadoLogoAsync(int id, EstadoGeneralEnum estadoLogo);
        Task CambiarEstadoNombreAsync(int id, EstadoNombreEnum estadoNombre);
        Task CambiarEstadoTelefonoAsync(int id, EstadoGeneralEnum estadoTelefono);
        InformacionEmpresaDTO ConvertToDTO(InformacionEmpresaModel model);
        InformacionEmpresaModel ConvertToModel(InformacionEmpresaDTO dto);
        Task<InformacionEmpresaModel> CrearInfosAsync(InformacionEmpresaModel infos);
        Task<InformacionEmpresaModel> ObtenerInfoPorIdAsync(int id);
        Task<List<InformacionEmpresaModel>> ObtenerListadoInformacionEmpresaAsync();
    }
}
