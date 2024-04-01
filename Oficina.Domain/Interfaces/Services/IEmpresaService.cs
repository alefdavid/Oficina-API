using OficinaOS.Domain.DTO;

namespace OficinaOS.Domain.Interfaces.Services
{
    public interface IEmpresaService : IService
    {
        Task<EmpresaCadastrarDTO> Post(EmpresaCadastrarDTO empresaCadastrar);
        Task<bool> Put(EmpresaAtualizarDTO empresaAtualizar, int id);
        Task<EmpresaDTO> GetByCnpj(string cnpj);
        Task<EmpresaDTO> GetById(int id);
        Task<List<EmpresaDTO>> GetAll();
        Task<bool> Delete(int id);
    }
}
