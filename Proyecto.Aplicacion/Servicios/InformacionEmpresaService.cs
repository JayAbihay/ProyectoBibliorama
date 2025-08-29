using AutoMapper;
using Proyecto.Aplicacion.Interfaces;
using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Entidades.DTOs;
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
    }
}
