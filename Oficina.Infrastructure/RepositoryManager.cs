using OficinaOS.Domain;
using OficinaOS.Domain.Interfaces.Repositories;
using OficinaOS.Infrastructure.Context;

namespace OficinaOS.Infrastructure
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly OficinaDbContext oficinaDbContext;

        private bool descartado;

        public IPessoaRepository PessoaRepository { get; }
        public IPecaRepository PecaRepository { get; }
        public IEmpresaRepository EmpresaRepository { get; }
        public RepositoryManager(OficinaDbContext oficinaDbContext,
                                IPessoaRepository pessoaRepository,
                                IPecaRepository pecaRepository,
                                IEmpresaRepository empresaRepository)
        {
            this.oficinaDbContext = oficinaDbContext;
            PessoaRepository = pessoaRepository;
            PecaRepository = pecaRepository;
            EmpresaRepository = empresaRepository;
        }

        public async Task Save()
        {
            await oficinaDbContext.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!descartado)
            {
                if (disposing)
                {
                    oficinaDbContext.Dispose();
                    PessoaRepository.Dispose();
                    PecaRepository.Dispose();
                    EmpresaRepository.Dispose();
                }
                descartado = true;
            }
        }

        ~RepositoryManager()
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
