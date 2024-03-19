using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OficinaOS.Domain.Interfaces.Repositories
{
    public interface IPecaRepository
    {
        Task<PecaDTO> BuscarPecaId(int id);
        Task<IQueryable<PecaDTO>> ListarPeca();
        Task<PecaDTO> CadastrarPeca(PecaDTO pecaDTO);
        Task<bool> AtualizarPeca(PecaDTO pecaAtualizar, int id);
        Task<bool> RemovePeca(int id);


    }
}
