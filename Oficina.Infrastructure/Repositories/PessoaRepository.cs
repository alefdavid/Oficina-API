using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using OficinaOS.Domain.Interfaces.Repositories;
using OficinaOS.Infrastructure.Context;
using System;

namespace OficinaOS.Infrastructure.Repositories
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(OficinaDbContext dbContext) : base(dbContext) { }
    }
}
