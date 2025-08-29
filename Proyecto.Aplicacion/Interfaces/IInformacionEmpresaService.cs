using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Entidades.DTOs;

namespace Proyecto.Aplicacion.Interfaces
{
    public interface IInformacionEmpresaService
    {
        InformacionEmpresaDTO ConvertToDTO(InformacionEmpresaModel model);
        InformacionEmpresaModel ConvertToModel(InformacionEmpresaDTO dto);
        Task<InformacionEmpresaModel> CrearInfosAsync(InformacionEmpresaModel infos);
        Task<InformacionEmpresaModel> ObtenerInfoPorIdAsync(int id);
        Task<List<InformacionEmpresaModel>> ObtenerListadoInformacionEmpresaAsync();
    }
}
