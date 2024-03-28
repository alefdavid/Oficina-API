using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaOS.Domain.Interfaces.Services
{
    public interface IPecaService : IService
    {
        Task<PecaCadastrarDTO> Cadastrar(PecaCadastrarDTO pecaCadastrar);
        Task<bool> Atualizar(PecaAtualizarDTO pecaAtualizar, int id);
        Task<PecaDTO> BuscarPorId(int id);
        Task<List<PecaDTO>> Listar();
        Task<bool> Excluir(int id);
    }
}
