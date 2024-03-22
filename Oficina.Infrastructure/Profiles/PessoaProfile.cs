using AutoMapper;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using System.Collections.Generic;

namespace OficinaOS.Infrastructure.Profiles
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<Pessoa, PessoaDTO>();
            CreateMap<PessoaCadastrarDTO, Pessoa>();
            CreateMap<Pessoa, PessoaCadastrarDTO>();
            CreateMap<PessoaAtualizarDTO, Pessoa>();
        }
    }
}
