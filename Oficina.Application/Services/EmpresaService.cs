using AutoMapper;
using OficinaOS.Domain;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using OficinaOS.Domain.Interfaces.Services;


namespace OficinaOS.Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IRepositoryManager _repositoryManager;

        private readonly IMapper _mapper;

        private bool descartado;

        public EmpresaService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<EmpresaDTO> GetByCnpj(string cnpj)
        {
            if (cnpj == null)
                throw new Exception();

            var listarEmpresa = await _repositoryManager.EmpresaRepository.GetAll();
            var empresa = listarEmpresa.Where(x => x.Cnpj == cnpj).FirstOrDefault();

            var empresaDTO = _mapper.Map<EmpresaDTO>(empresa);

            return empresaDTO;
        }

        public async Task<EmpresaDTO> GetById(int id)
        {
            if (id == null)
                throw new Exception();

            var listarEmpresa = await _repositoryManager.EmpresaRepository.GetAll();
            var empresa = listarEmpresa.Where(x => x.Id == id).FirstOrDefault();

            var empresaDTO = _mapper.Map<EmpresaDTO>(empresa);

            return empresaDTO;
        }

        public async Task<List<EmpresaDTO>> GetAll()
        {
            var listarEmpresa = await _repositoryManager.EmpresaRepository.GetAll();
            var listarEmpresaDTO = _mapper.Map<List<EmpresaDTO>>(listarEmpresa);

            return listarEmpresaDTO;
        }

        public async Task<EmpresaCadastrarDTO> Post(EmpresaCadastrarDTO empresaCadastrar)
        {
            if (empresaCadastrar == null)
                throw new ArgumentNullException(nameof(empresaCadastrar));

            var empresa = _mapper.Map<EmpresaCadastrarDTO, Empresa>(empresaCadastrar);

            _repositoryManager.EmpresaRepository.Add(empresa);
            await _repositoryManager.Save();

            return _mapper.Map<Empresa, EmpresaCadastrarDTO>(empresa);
        }

        public async Task<bool> Put(EmpresaAtualizarDTO empresaAtualizar, int id)
        {
            if (empresaAtualizar == null)
                throw new ArgumentNullException(nameof(empresaAtualizar));

            var empresa = await _repositoryManager.EmpresaRepository.GetAll();
            var empresaExistente = empresa.Where(x => x.Id == id).FirstOrDefault();

            if (empresaExistente == null)
                throw new ArgumentNullException($"Não existe: {empresaExistente}.");

            _mapper.Map(empresaAtualizar, empresaExistente);

            _repositoryManager.EmpresaRepository.Put(empresaExistente);

            await _repositoryManager.Save();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            var empresa = await _repositoryManager.EmpresaRepository.GetAll();
            var retornaRemoverEmpresa = empresa.Where(x => x.Id == id).FirstOrDefault();

            if (retornaRemoverEmpresa == null)
                throw new ArgumentNullException($"Não existe: {id}.");

            await _repositoryManager.EmpresaRepository.Delete(retornaRemoverEmpresa.Id);

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

        ~EmpresaService()
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
