using Proyecto.Dominio.Entidades;

namespace Proyecto.Dominio.Interfaces
{
    public interface IInformacionEmpresaRepositorio
    {
        Task CrearInformacionEmpresa(InformacionEmpresaModel infoEmpresa);
        Task<InformacionEmpresaModel> ObtenerInformacionEmpresaPorId(int id);
        Task<List<InformacionEmpresaModel>> ObtenerListadoInformacionEmpresa();
    }
}
