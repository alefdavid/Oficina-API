using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using OficinaOS.Domain.Interfaces.Repositories;
using OficinaOS.Infrastructure.Context;

namespace OficinaOS.Infrastructure.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly OficinaDbContext _context;

        private readonly IMapper _mapper;

        public PessoaRepository(OficinaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Pessoa> BuscarPorId(int id)
        {
            if (id == null)
                throw new Exception();

            var pessoa = _context.Pessoas.Where(x => x.Id == id).FirstOrDefault();
                
            return pessoa;
        }

        public async Task<List<Pessoa>> Listar()
        {
            return await _context.Pessoas.ToListAsync();
        }

        public async Task<PessoaCadastrarDTO> Cadastrar(PessoaCadastrarDTO pessoaCadastrar)
        {
            if (pessoaCadastrar == null)
                throw new ArgumentNullException(nameof(pessoaCadastrar));

            var pessoa = _mapper.Map<PessoaCadastrarDTO, Pessoa>(pessoaCadastrar);

            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();

            return _mapper.Map<Pessoa, PessoaCadastrarDTO>(pessoa);            
        }

        public async Task<bool> Atualizar(PessoaAtualizarDTO pessoaAtualizar, int id)
        {
            if (pessoaAtualizar == null)
                throw new ArgumentNullException(nameof(pessoaAtualizar));

            var pessoaExistente = await _context.Pessoas
                .FirstOrDefaultAsync(a => a.Id == id);

            if (pessoaExistente == null)
                throw new ArgumentNullException($"Não existe: {pessoaExistente}.");

            _mapper.Map(pessoaAtualizar,pessoaExistente);
                       
            _context.Pessoas.Update(pessoaExistente);

            await _context.SaveChangesAsync();

            return true;
        }
      
        public async Task<bool> Excluir(int id)
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
