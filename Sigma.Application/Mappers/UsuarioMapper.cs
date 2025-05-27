using AutoMapper;
using Sigma.Application.Dtos;
using Sigma.Domain.Entities;
using Sigma.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Application.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<UsuarioDTo, Usuario>()
                .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.Cargo.Equals("Administrador", StringComparison.OrdinalIgnoreCase) ? Cargo.Administrador : Cargo.Cliente));
            CreateMap<Usuario, UsuarioDTo>()
                .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.Cargo.ToString()));




        }
    }
}
