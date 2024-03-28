using AutoMapper;
using OficinaOS.Domain;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using OficinaOS.Domain.Interfaces.Services;


namespace OficinaOS.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IRepositoryManager _repositoryManager;

        private readonly IMapper _mapper;

        private bool descartado;

        public PessoaService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<PessoaDTO> BuscarPorId(int id)
        {
            if (id == null)
                throw new Exception();

            var listarPessoas = await _repositoryManager.PessoaRepository.Listar();
            var pessoa = listarPessoas.Where(x => x.Id == id).FirstOrDefault();

            var pessoaDTO = _mapper.Map<PessoaDTO>(pessoa);

            return pessoaDTO;
        }

        public async Task<List<PessoaDTO>> Listar()
        {
            var listarPessoas = await _repositoryManager.PessoaRepository.Listar();
            var listarPessoasDTO = _mapper.Map<List<PessoaDTO>>(listarPessoas);

            return listarPessoasDTO;
        }

        public async Task<PessoaCadastrarDTO> Cadastrar(PessoaCadastrarDTO pessoaCadastrar)
        {
            if (pessoaCadastrar == null)
                throw new ArgumentNullException(nameof(pessoaCadastrar));

            var pessoa = _mapper.Map<PessoaCadastrarDTO, Pessoa>(pessoaCadastrar);

            _repositoryManager.PessoaRepository.Adicionar(pessoa);
            await _repositoryManager.Save();

            return _mapper.Map<Pessoa, PessoaCadastrarDTO>(pessoa);
        }

        public async Task<bool> Atualizar(PessoaAtualizarDTO pessoaAtualizar, int id)
        {
            if (pessoaAtualizar == null)
                throw new ArgumentNullException(nameof(pessoaAtualizar));

            var pessoa = await _repositoryManager.PessoaRepository.Listar();
            var pessoaExistente = pessoa.Where(x => x.Id == id).FirstOrDefault();

            if (pessoaExistente == null)
                throw new ArgumentNullException($"Não existe: {pessoaExistente}.");

            _mapper.Map(pessoaAtualizar, pessoaExistente);

            _repositoryManager.PessoaRepository.Atualizar(pessoaExistente);

            await _repositoryManager.Save();

            return true;
        }

        public async Task<bool> Excluir(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var pessoa = await _repositoryManager.PessoaRepository.Listar();
            var retornaRemoverPessoa = pessoa.Where(x => x.Id == id).FirstOrDefault();

            if (retornaRemoverPessoa == null)
                throw new ArgumentNullException($"Não existe: {id}.");

            await _repositoryManager.PessoaRepository.Excluir(retornaRemoverPessoa.Id);

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

        ~PessoaService()
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
