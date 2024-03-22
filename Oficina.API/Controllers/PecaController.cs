using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OficinaOS.API.Responses;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Interfaces.Repositories;

namespace OficinaOS.API.Controllers
{
    [ApiController]
    public class PecaController : MainController
    {
        private readonly IPecaRepository _pecaRepository;

        private readonly IMapper _mapper;
        public PecaController(IPecaRepository pecaRepository, IMapper mapper)
        {
            _pecaRepository = pecaRepository;
            _mapper = mapper;
        }

        [HttpGet("/api/buscar/peca/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PecaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]
        public async Task<IActionResult> BuscarPecaId(int id)
        {
            try
            {
                var retorno = await _pecaRepository.BuscarPorId(id);

                if (retorno == null)
                    return NotFoundResponse();

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                ShowConsoleError(ex);

                return BadResponse(MensagemErro.Erro_Inesperado);
            }
        }

        [HttpGet("/api/listar/peca")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PecaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]
        public async Task<IActionResult> ListarPeca()
        {
            try
            {
                var retorno = await _pecaRepository.Listar();

                if (retorno == null)
                    return NotFoundResponse();

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                ShowConsoleError(ex);

                return BadResponse(MensagemErro.Erro_Inesperado);
            }
        }

        [HttpPost("/api/cadastrar/peca/")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PecaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]

        public async Task<IActionResult> CadastrarPeca([FromBody] PecaDTO pecaDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var lista = ModelState.Where(x => x.Value.ValidationState == ModelValidationState.Invalid)
                        .SelectMany(item => item.Value.Errors.ToList(), (item, errors) => new { item, errors })
                        .Select(x => x.errors.ErrorMessage)
                        .ToList();

                    return BadResponse(lista);
                }

                var pecaCadastrar = _mapper.Map<PecaDTO>(pecaDTO);

                var retorno = await _pecaRepository.Cadastrar(pecaCadastrar);

                if (retorno == null)
                    return NotFoundResponse();

                return Ok(retorno);
            }

            catch (Exception ex)
            {
                ShowConsoleError(ex);

                return BadResponse(MensagemErro.Erro_Inesperado);
            }
        }

        [HttpPut("/api/atualizar/peca/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PecaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]

        public async Task<IActionResult> AtualizarPeca([FromBody] PecaDTO pecaDTO, int id)
        {
            try
            {
                var retornoBuscarId = await _pecaRepository.BuscarPorId(id);

                if (retornoBuscarId == null)
                    return NotFoundResponse();

                var pecaAtualizar = _mapper.Map<PecaDTO>(pecaDTO);

                var retorno = await _pecaRepository.Atualizar(pecaAtualizar, id);

                if (retorno == null)
                    return NotFoundResponse();

                return Ok(retorno);
            }

            catch (Exception ex)
            {
                ShowConsoleError(ex);

                return BadResponse(MensagemErro.Erro_Inesperado);
            }
        }

        [HttpDelete("/api/deletar/peca/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]

        public async Task<IActionResult> DeletarPessoa(int id)
        {
            try
            {
                var retorno = await _pecaRepository.Excluir(id);

                if (retorno == null)
                    return NotFoundResponse();

                return Ok(retorno);
            }

            catch (Exception ex)
            {
                ShowConsoleError(ex);

                return BadResponse(MensagemErro.Erro_Inesperado);
            }
        }
    }
}
