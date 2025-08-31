using AutoMapper;
using Proyecto.Aplicacion.Interfaces;
using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Entidades.DTOs;
using Proyecto.Dominio.Entidades.Enums;
using Proyecto.Dominio.Interfaces;

namespace Proyecto.Aplicacion.Servicios
{
    public class InformacionEmpresaService : IInformacionEmpresaService
    {
        private readonly IInformacionEmpresaRepositorio _informacionEmpresaRepositorio;
        private readonly IMapper _mapper;
        
        public InformacionEmpresaService(IInformacionEmpresaRepositorio informacionEmpresaRepositorio, IMapper mapper)
        {
            _informacionEmpresaRepositorio = informacionEmpresaRepositorio;
            _mapper = mapper;
        }

        public InformacionEmpresaModel ConvertToModel(InformacionEmpresaDTO dto)
        {
            return _mapper.Map<InformacionEmpresaModel>(dto);
        }

        public InformacionEmpresaDTO ConvertToDTO(InformacionEmpresaModel model)
        {
            return _mapper.Map<InformacionEmpresaDTO>(model);
        }

        public async Task<List<InformacionEmpresaModel>> ObtenerListadoInformacionEmpresaAsync()
        {
            var listadoInfos = await _informacionEmpresaRepositorio.ObtenerListadoInformacionEmpresa();
            return listadoInfos;
        }


        public async Task<InformacionEmpresaModel> ObtenerInfoPorIdAsync(int id)
        {
            var infoId = await _informacionEmpresaRepositorio.ObtenerInformacionEmpresaPorId(id);
            return infoId;
        }

        public async Task<InformacionEmpresaModel> CrearInfosAsync(InformacionEmpresaModel infos)
        {
            await _informacionEmpresaRepositorio.CrearInformacionEmpresa(infos);
            var infoId = infos.Id;
            var infoCreado = await ObtenerInfoPorIdAsync(infoId);
            return infoCreado;
        }

        public async Task CambiarEstadoNombreAsync(int id, EstadoNombreEnum estadoNombre)
        {
            await _informacionEmpresaRepositorio.CambiarEstadoNombre(id, estadoNombre);
        }

        public async Task CambiarEstadoDireccionAsync(int id, EstadoDireccionEnum estadoDireccion)
        {
            await _informacionEmpresaRepositorio.CambiarEstadoDireccion(id, estadoDireccion);
        }
        public async Task CambiarEstadoDescripcionAsync(int id, EstadoGeneralEnum estadoDescripcion)
        {
            await _informacionEmpresaRepositorio.CambiarEstadoDescripcion(id, estadoDescripcion);
        }

        public async Task CambiarEstadoTelefonoAsync(int id, EstadoGeneralEnum estadoTelefono)
        {
            await _informacionEmpresaRepositorio.CambiarEstadoTelefono(id, estadoTelefono);
        }

        public async Task CambiarEstadoCorreoElectronicoAsync(int id, EstadoGeneralEnum estadoCorreoElectronico)
        {
            await _informacionEmpresaRepositorio.CambiarEstadoCorreoElectronico(id, estadoCorreoElectronico);
        }

        public async Task CambiarEstadoIdentificacionAsync(int id, EstadoGeneralEnum estadoIdentificacion)
        {
            await _informacionEmpresaRepositorio.CambiarEstadoIdentificacion(id, estadoIdentificacion);
        }

        public async Task CambiarEstadoLogoAsync(int id, EstadoGeneralEnum estadoLogo)
        {
            await _informacionEmpresaRepositorio.CambiarEstadoLogo(id, estadoLogo);
        }

        public async Task CambiarEstadoCarouselImage1PathAsync(int id, EstadoGeneralEnum estadoCarouselImage1Path)
        {
            await _informacionEmpresaRepositorio.CambiarEstadoCarouselImage1(id, estadoCarouselImage1Path);
        }

        public async Task CambiarEstadoCarouselImage2PathAsync(int id, EstadoGeneralEnum estadoCarouselImage2Path)
        {
            await _informacionEmpresaRepositorio.CambiarEstadoCarouselImage2(id, estadoCarouselImage2Path);
        }

        public async Task CambiarEstadoCarouselImage3PathAsync(int id, EstadoGeneralEnum estadoCarouselImage3Path)
        {
            await _informacionEmpresaRepositorio.CambiarEstadoCarouselImage3(id, estadoCarouselImage3Path);
        }

        public async Task CambiarEstadoDescripcionCarousel1Async(int id, EstadoGeneralEnum estadoDescripcionCarousel1)
        {
            await _informacionEmpresaRepositorio.CambiarEstadoDescripcionCarousel1(id, estadoDescripcionCarousel1);
        }

        public async Task CambiarEstadoDescripcionCarousel2Async(int id, EstadoGeneralEnum estadoDescripcionCarousel2)
        {
            await _informacionEmpresaRepositorio.CambiarEstadoDescripcionCarousel2(id, estadoDescripcionCarousel2);
        }

        public async Task CambiarEstadoDescripcionCarousel3Async(int id, EstadoGeneralEnum estadoDescripcionCarousel3)
        {
            await _informacionEmpresaRepositorio.CambiarEstadoDescripcionCarousel3(id, estadoDescripcionCarousel3);
        }

    }
}
