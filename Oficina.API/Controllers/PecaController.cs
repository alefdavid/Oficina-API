using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OficinaOS.API.Responses;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Interfaces.Repositories;
using OficinaOS.Domain.Interfaces.Services;

namespace OficinaOS.API.Controllers
{
    [ApiController]
    public class PecaController : MainController
    {
        private readonly IPecaService _pecaService;

        private readonly IMapper _mapper;
        public PecaController(IPecaService pecaService, IMapper mapper)
        {
            _pecaService = pecaService;
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
                var retorno = await _pecaService.BuscarPorId(id);

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
                var retorno = await _pecaService.Listar();

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PecaCadastrarDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]

        public async Task<IActionResult> CadastrarPeca([FromBody] PecaCadastrarDTO pecaCadastrarDTO)
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

                var pecaCadastrar = _mapper.Map<PecaCadastrarDTO>(pecaCadastrarDTO);

                var retorno = await _pecaService.Cadastrar(pecaCadastrar);

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PecaAtualizarDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]

        public async Task<IActionResult> AtualizarPeca([FromBody] PecaAtualizarDTO pecaAtualizarDTO, int id)
        {
            try
            {
                var retornoBuscarId = await _pecaService.BuscarPorId(id);

                if (retornoBuscarId == null)
                    return NotFoundResponse();

                var pecaAtualizar = _mapper.Map<PecaAtualizarDTO>(pecaAtualizarDTO);

                var retorno = await _pecaService.Atualizar(pecaAtualizar, id);

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
                var retorno = await _pecaService.Excluir(id);

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
