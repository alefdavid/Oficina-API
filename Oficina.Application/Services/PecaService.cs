using AutoMapper;
using OficinaOS.Domain;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using OficinaOS.Domain.Interfaces.Services;

namespace OficinaOS.Application.Services
{
    public class PecaService : IPecaService
    {
        private readonly IRepositoryManager _repositoryManager;

        private readonly IMapper _mapper;

        private bool descartado;

        public PecaService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<PecaDTO> GetById(int id)
        {
            if (id == null)
                throw new Exception();

            var listarPeca = await _repositoryManager.PecaRepository.GetAll();
            var peca = listarPeca.Where(x => x.Id == id).FirstOrDefault();

            var pessoaDTO = _mapper.Map<PecaDTO>(peca);

            return pessoaDTO;
        }

        public async Task<List<PecaDTO>> GetAll()
        {
            var listarPeca = await _repositoryManager.PecaRepository.GetAll();
            var listarPecaDTO = _mapper.Map<List<PecaDTO>>(listarPeca);

            return listarPecaDTO;
        }

        public async Task<PecaCadastrarDTO> Post(PecaCadastrarDTO pecaCadastrar)
        {
            if (pecaCadastrar == null)
                throw new ArgumentNullException(nameof(pecaCadastrar));

            var peca = _mapper.Map<PecaCadastrarDTO, Peca>(pecaCadastrar);

            _repositoryManager.PecaRepository.Add(peca);
            await _repositoryManager.Save();

            return _mapper.Map<Peca, PecaCadastrarDTO>(peca);
        }

        public async Task<bool> Put(PecaAtualizarDTO pecaAtualizar, int id)
        {
            if (pecaAtualizar == null)
                throw new ArgumentNullException(nameof(pecaAtualizar));

            var listarPeca = await _repositoryManager.PecaRepository.GetAll();
            var pecaExistente = listarPeca.Where(x => x.Id == id).FirstOrDefault();

            if (pecaExistente == null)
                throw new ArgumentNullException($"Não existe: {pecaExistente}.");

            _mapper.Map(pecaAtualizar, pecaExistente);

            _repositoryManager.PecaRepository.Put(pecaExistente);

            await _repositoryManager.Save();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var listarPeca = await _repositoryManager.PecaRepository.GetAll();
            var retornaRemoverPeca = listarPeca.Where(x => x.Id == id).FirstOrDefault();

            if (retornaRemoverPeca == null)
                throw new ArgumentNullException($"Não existe: {id}.");

            await _repositoryManager.PecaRepository.Delete(retornaRemoverPeca.Id);

            await _repositoryManager.Save();

            return true;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!descartado)
            {
                if (disposing)
                {
                    _repositoryManager.Dispose();
                }

                descartado = true;
            }
        }
        ~PecaService()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
