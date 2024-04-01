using AutoMapper;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using System.Collections.Generic;

namespace OficinaOS.Infrastructure.Profiles
{
    public class EmpresaProfile : Profile
    {
        public EmpresaProfile()
        {
            CreateMap<Empresa, EmpresaDTO>();
            CreateMap<EmpresaDTO, Empresa>();
            CreateMap<EmpresaCadastrarDTO, Empresa>();
            CreateMap<Empresa, EmpresaCadastrarDTO>();
            CreateMap<EmpresaAtualizarDTO, Empresa>();
        }
    }
}
