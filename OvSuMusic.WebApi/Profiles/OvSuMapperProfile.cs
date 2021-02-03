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

        }
    }
}
