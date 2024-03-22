using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using OficinaOS.Domain.Interfaces.Repositories;
using OficinaOS.Infrastructure.Context;

namespace OficinaOS.Infrastructure.Repositories
{
    public class PecaRepository : IPecaRepository
    {
        private readonly OficinaDbContext _context;

        private readonly IMapper _mapper;

        public PecaRepository(OficinaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Peca> BuscarPorId(int id)
        {
            if (id == null)
                throw new Exception();
            
            var peca = _context.Pecas.Where(x => x.Id == id).FirstOrDefault();

            return peca;
        }

        public async Task<List<Peca>> Listar()
        {
            return await _context.Pecas.ToListAsync();
        }

        public async Task<PecaDTO> Cadastrar(PecaDTO pecaCadastrar)
        {
            if (pecaCadastrar == null)
                throw new ArgumentNullException(nameof(pecaCadastrar));

            var peca = _mapper.Map<PecaDTO, Peca>(pecaCadastrar);

            _context.Pecas.Add(peca);
            await _context.SaveChangesAsync();

            return _mapper.Map<Peca, PecaDTO>(peca);
        }

        public async Task<bool> Atualizar(PecaDTO pecaAtualizar, int id)
        {
            if (pecaAtualizar == null)
                throw new ArgumentNullException(nameof(pecaAtualizar));

            var pecaExistente = await _context.Pecas
                .FirstOrDefaultAsync(a => a.Id == id);

            if (pecaExistente == null)
                throw new ArgumentNullException($"Não existe: {pecaExistente}.");

            _mapper.Map(pecaAtualizar, pecaExistente);

            _context.Pecas.Update(pecaExistente);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Excluir(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var retornaDeletarPeca = await _context.Pecas.FindAsync(id);

            if (retornaDeletarPeca == null)
                throw new ArgumentNullException($"Não existe: {id}.");

            _context.Pecas.Remove(retornaDeletarPeca);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
