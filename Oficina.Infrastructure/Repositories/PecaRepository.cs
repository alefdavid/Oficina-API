using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using OficinaOS.Domain.Interfaces.Repositories;
using OficinaOS.Infrastructure.Context;

namespace OficinaOS.Infrastructure.Repositories
{
    public class PecaRepository : Repository<Peca>, IPecaRepository
    {
        public PecaRepository(OficinaDbContext dbContext) : base(dbContext) { }
    }
}

