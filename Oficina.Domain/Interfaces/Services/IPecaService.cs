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
        Task<PecaCadastrarDTO> Post(PecaCadastrarDTO pecaCadastrar);
        Task<bool> Put(PecaAtualizarDTO pecaAtualizar, int id);
        Task<PecaDTO> GetById(int id);
        Task<List<PecaDTO>> GetAll();
        Task<bool> Delete(int id);
    }
}
