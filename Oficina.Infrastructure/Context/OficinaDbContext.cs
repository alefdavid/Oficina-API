using Microsoft.EntityFrameworkCore;
using Oficina.Domain.Entities;
using Oficina.Infrastructure.Configurations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Infrastructure.Context
{
    public class OficinaDbContext : DbContext
    {
        public OficinaDbContext()
        {
        }

        public OficinaDbContext(DbContextOptions<OficinaDbContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Peca> Pecas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());            
        }   
    }
}
