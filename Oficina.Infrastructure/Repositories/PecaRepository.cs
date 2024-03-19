using Oficina.Domain.DTO;
using Oficina.Domain.Entities;
using Oficina.Domain.Interfaces.Repositories;
using Oficina.Infrastructure.Context;
using System.Linq;

namespace Oficina.Infrastructure.Repositories
{
    public class PecaRepository : IPecaRepository
    {
        private readonly OficinaDbContext _context = new OficinaDbContext();

        public PecaRepository(OficinaDbContext context)
        {
            _context = context;
        }

        public async Task<PecaDTO> BuscarPecaId(int id)
        {
            if (id == null)
            {
                throw new Exception();
            }

            var listaPeca = _context.Pecas.Where(x => x.Codigo == id).FirstOrDefault();

            return new PecaDTO
            {
                Descricao = listaPeca.Descricao,
                Quantidade = listaPeca.Quantidade,
                Marca = listaPeca.Marca,
                Valor_unit = listaPeca.Valor_unit
            };
        }

        public async Task<IQueryable<PecaDTO>> ListarPeca()
        {
            var listaPeca = _context.Pecas;

            var pecaDTO = listaPeca.Select(p => new PecaDTO
            {
                Id = p.Codigo,
                Descricao = p.Descricao,
                Quantidade = p.Quantidade,
                Marca = p.Marca,
                Valor_unit = p.Valor_unit
            });

            return pecaDTO;
        }

        public async Task<PecaDTO> CadastrarPeca(PecaDTO pecaDTO)
        {
            if (pecaDTO == null)
                throw new ArgumentNullException(nameof(pecaDTO));

            var entidadePeca = new Peca
            {
                Descricao = pecaDTO.Descricao,
                Quantidade = pecaDTO.Quantidade,
                Marca = pecaDTO.Marca,
                Valor_unit = pecaDTO.Valor_unit
            };

            var retorno = _context.Pecas.Add(entidadePeca).Entity;
            await _context.SaveChangesAsync();

            return new PecaDTO
            {
                Descricao = retorno.Descricao,
                Quantidade = retorno.Quantidade,
                Marca = retorno.Marca,
                Valor_unit = retorno.Valor_unit
            };
        }

        public async Task<bool> AtualizarPeca(PecaDTO pecaAtualizar, int id)
        {
            if (pecaAtualizar == null)
                throw new ArgumentNullException(nameof(pecaAtualizar));

            var retornaAtualizarPeca = await _context.Pecas.FindAsync(id);

            if (retornaAtualizarPeca == null)
                throw new ArgumentNullException($"Não existe: {id}.");

            retornaAtualizarPeca.Descricao = pecaAtualizar.Descricao;
            retornaAtualizarPeca.Quantidade = pecaAtualizar.Quantidade;
            retornaAtualizarPeca.Marca = pecaAtualizar.Marca;
            retornaAtualizarPeca.Valor_unit = pecaAtualizar.Valor_unit;

            _context.Pecas.Update(retornaAtualizarPeca);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemovePeca(int id)
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
