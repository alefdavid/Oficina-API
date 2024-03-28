using Microsoft.EntityFrameworkCore;
using OficinaOS.Domain.Entities;
using OficinaOS.Domain.Interfaces.Repositories;
using OficinaOS.Infrastructure.Context;

namespace OficinaOS.Infrastructure.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly OficinaDbContext _context;
        private bool descartado;

        public Repository(OficinaDbContext context)
        {
            _context = context;
        }
        public void Adicionar(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Atualizar(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public async Task<T> BuscarPorId(int id)
        {
            return await _context.Set<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> Excluir(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
                return false;

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<T>> Listar()
        {
            return await _context.Set<T>().ToListAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!descartado)
            {
                if (disposing)
                {
                    this._context.Dispose();
                }

                descartado = true;
            }
        }

        ~Repository()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
