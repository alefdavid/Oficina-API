using OficinaOS.Domain.DTO;

namespace OficinaOS.Domain.Interfaces.Services
{
    public interface IPessoaService : IService
    {
        Task<PessoaCadastrarDTO> Post(PessoaCadastrarDTO pessoaCadastrar);
        Task<bool> Put(PessoaAtualizarDTO pessoaAtualizar, int id);
        Task<PessoaDTO> GetById(int id);
        Task<List<PessoaDTO>> GetAll();
        Task<bool> Delete(int id);
    }
}
