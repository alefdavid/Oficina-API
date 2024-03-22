using AutoMapper;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using System.Collections.Generic;

namespace OficinaOS.Infrastructure.Profiles
{
    public class PecaProfile : Profile
    {
        public PecaProfile()
        {       
            CreateMap<Peca, PecaDTO>();
            CreateMap<PecaDTO, Peca>();
        }
    }
}
