using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OficinaOS.Domain.Interfaces.Repositories;

namespace OficinaOS.Domain
{
    public interface IRepositoryManager : IDisposable
    {
        IPessoaRepository PessoaRepository { get; }
        IPecaRepository PecaRepository { get; }
        IEmpresaRepository EmpresaRepository { get; }
        Task Save();
    }
}
