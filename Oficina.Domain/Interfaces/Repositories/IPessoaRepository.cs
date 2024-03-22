using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;

namespace OficinaOS.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository : IBaseRepository<Pessoa>
    {
        Task<PessoaCadastrarDTO> Cadastrar(PessoaCadastrarDTO pessoaCadastrar);
        Task<bool> Atualizar(PessoaAtualizarDTO pessoaAtualizar, int id);
    }
}
