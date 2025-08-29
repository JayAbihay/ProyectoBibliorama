using AutoMapper;
using Proyecto.Dominio.Entidades;
using Proyecto.Dominio.Entidades.DTOs;

namespace Proyecto.Aplicacion.Perfil
{
    public class AutoMapperProfile : Profile
    {
       public AutoMapperProfile()
        {
            CreateMap<CategoriaModel, CategoriaDTO>();
            CreateMap<CategoriaDTO, CategoriaModel>();

            CreateMap<LibrosModel, LibrosDTO>();
            CreateMap<LibrosDTO, LibrosModel>();
        }

    }
}
