using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OvSuMusic.Dtos;
using OvSuMusic.Models;

namespace OvSuMusic.WebApi.Profiles
{
    public class OvSuMapperProfile : Profile
    {
        public OvSuMapperProfile()
        {
            this.CreateMap<Producto, ProductoDto>().ReverseMap();

            this.CreateMap<Perfil, PerfilDto>().ReverseMap();

            this.CreateMap<Orden, OrdenDto>()
                .ForMember(u => u.Usuario, p => p.MapFrom(m => m.Usuario.Username))
                .ReverseMap()
                .ForMember(u => u.Usuario, p => p.Ignore());

            this.CreateMap<DetalleOrden, DetalleOrdenDto>()
                .ForMember(u => u.Producto, p => p.MapFrom(u => u.Producto.Nombre))
                .ReverseMap()
                .ForMember(u => u.Producto, p => p.Ignore());

            this.CreateMap<Usuario, UsuarioRegistroDto>()
                .ForMember(u => u.Perfil, p => p.MapFrom(m => m.Perfil.Nombre))
                .ReverseMap()
                .ForMember(u => u.Perfil, p => p.Ignore());

            this.CreateMap<Usuario, UsuarioActualizacionDto>()
                .ReverseMap();

            this.CreateMap<Usuario, UsuarioListaDto>()
                .ForMember(u => u.Perfil, p => p.MapFrom(m => m.Perfil.Nombre))
                .ForMember(u => u.NombreCompleto, p => p.MapFrom(m => string.Format("{0} {1}",
                        m.Nombre, m.Apellidos)))
                .ReverseMap();

            this.CreateMap<Usuario, LoginModelDto>().ReverseMap();

            this.CreateMap<Usuario, PerfilUsuarioDto>().ReverseMap();
        }
    }
}
