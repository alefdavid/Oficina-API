using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;

namespace OficinaOS.Domain.Interfaces.Repositories
{
    public interface IPecaRepository : IBaseRepository<Peca>
    {
        Task<PecaDTO> Cadastrar(PecaDTO pecaCadastrar);
        Task<bool> Atualizar(PecaDTO pecaAtualizar, int id);
    }
}
