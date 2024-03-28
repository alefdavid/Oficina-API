using OficinaOS.Domain.DTO;

namespace OficinaOS.Domain.Interfaces.Services
{
    public interface IPessoaService : IService
    {
        Task<PessoaCadastrarDTO> Cadastrar(PessoaCadastrarDTO pessoaCadastrar);
        Task<bool> Atualizar(PessoaAtualizarDTO pessoaAtualizar, int id);
        Task<PessoaDTO> BuscarPorId(int id);
        Task<List<PessoaDTO>> Listar();
        Task<bool> Excluir(int id);
    }
}
