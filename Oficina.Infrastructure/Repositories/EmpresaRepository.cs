using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using OficinaOS.Domain.Interfaces.Repositories;
using OficinaOS.Infrastructure.Context;
using System;

namespace OficinaOS.Infrastructure.Repositories
{
    public class EmpresaRepository : Repository<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(OficinaDbContext dbContext) : base(dbContext) { }
    }
}
