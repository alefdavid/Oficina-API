using Oficina.Domain.DTO;
using Oficina.Domain.Entities;
using Oficina.Domain.Interfaces.Repositories;
using Oficina.Infrastructure.Context;
using System.Linq;

namespace Oficina.Infrastructure.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly OficinaDbContext _context = new OficinaDbContext();

        public PessoaRepository(OficinaDbContext context)
        {
            _context = context;
        }

        public async Task<CadastrarPessoaDTO> BuscarPessoaId(int id)
        {
            if (id == null)
            {
                throw new Exception();
            }

            var listaPessoa = _context.Pessoas.Where(x => x.Codigo == id).FirstOrDefault();

            return new CadastrarPessoaDTO
            {
                Nome = listaPessoa.Nome,
                Cpf = listaPessoa.Cpf,
                Email = listaPessoa.Email,
                Telefone = listaPessoa.Telefone
            };
        }
        public async Task<IQueryable<CadastrarPessoaDTO>> ListarPessoa()
        {
            var listaPessoa = _context.Pessoas;

            var pessoaDto = listaPessoa.Select(p => new CadastrarPessoaDTO
            {
                Id = p.Codigo,
                Nome = p.Nome,                
                Cpf = p.Cpf,
                Telefone = p.Telefone,
                Email = p.Email
            });

            return pessoaDto;
        }

        public async Task<CadastrarPessoaDTO> CadastrarPessoa(CadastrarPessoaDTO pessoaDTO)
        {
            if (pessoaDTO == null)
                throw new ArgumentNullException(nameof(pessoaDTO));

            var entidadePessoa = new Pessoa
            {
                Nome = pessoaDTO.Nome,
                Cpf = pessoaDTO.Cpf,
                Telefone = pessoaDTO.Telefone,
                Email = pessoaDTO.Email,               
                Senha = pessoaDTO.Senha
                
            };

            var retorno = _context.Pessoas.Add(entidadePessoa).Entity;
            await _context.SaveChangesAsync();

            return new CadastrarPessoaDTO
            {
                Nome = retorno.Nome,
                Cpf = retorno.Cpf,
                Telefone = retorno.Telefone,
                Email = retorno.Email,
                Senha = retorno.Senha
            };
        }

        public async Task<bool> AtualizarPessoa(CadastrarPessoaDTO pessoaAtualizar, int id)
        {
            if (pessoaAtualizar == null)
                throw new ArgumentNullException(nameof(pessoaAtualizar));

            var retornaAtualizarPessoa = await _context.Pessoas.FindAsync(id);

            if (retornaAtualizarPessoa == null)
                throw new ArgumentNullException($"Não existe: {id}.");

            retornaAtualizarPessoa.Nome = pessoaAtualizar.Nome;
            retornaAtualizarPessoa.Cpf = pessoaAtualizar.Cpf;
            retornaAtualizarPessoa.Telefone = pessoaAtualizar.Telefone;
            retornaAtualizarPessoa.Email = pessoaAtualizar.Email;
            retornaAtualizarPessoa.Senha = pessoaAtualizar.Senha;
                       
            _context.Pessoas.Update(retornaAtualizarPessoa);

            await _context.SaveChangesAsync();

            return true;
        }
      
        public async Task<bool> RemovePessoa(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var retornaRemovePessoa = await _context.Pessoas.FindAsync(id);

            if (retornaRemovePessoa == null)
                throw new ArgumentNullException($"Não existe: {id}.");

            _context.Pessoas.Remove(retornaRemovePessoa);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
