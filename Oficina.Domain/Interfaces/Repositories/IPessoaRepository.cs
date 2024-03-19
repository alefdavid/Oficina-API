using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaOS.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        Task<CadastrarPessoaDTO> BuscarPessoaId(int id);
        Task<IQueryable<CadastrarPessoaDTO>> ListarPessoa();
        Task<CadastrarPessoaDTO> CadastrarPessoa(CadastrarPessoaDTO pessoaDTO);
        Task<bool> AtualizarPessoa(CadastrarPessoaDTO pessoaAtualizar, int id);       
        Task<bool> RemovePessoa(int id);
    }
}
