using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OvSuMusic.Dtos;
using OvSuMusic.Models;

namespace OvSuMusic.WebApi.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            this.CreateMap<Producto, ProductoDto>().ReverseMap();
        }
    }
}
