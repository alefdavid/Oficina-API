using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OficinaOS.API.Responses;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using OficinaOS.Domain.Interfaces.Services;

namespace OficinaOS.API.Controllers
{
    [ApiController]
    public class PessoaController : MainController
    {
        private readonly IPessoaService _pessoaService;

        private readonly IMapper _mapper;

        public PessoaController(IPessoaService pessoaService,
                                IMapper mapper)
        {
            _pessoaService = pessoaService;
            _mapper = mapper;
        }

        [HttpGet("/api/buscar/pessoa/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]
        public async Task<IActionResult> BuscarPessoaId(int id)
        {
            try
            {
                var retorno = await _pessoaService.BuscarPorId(id);

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

        [HttpGet("/api/listar/pessoa")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]
        public async Task<IActionResult> ListarPessoa()
        {
            try
            {
                var retorno = await _pessoaService.Listar();

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

        [HttpPost("/api/cadastrar/pessoa/")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaCadastrarDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]

        public async Task<IActionResult> CadastrarPessoa([FromBody] PessoaCadastrarDTO pessoaCadastrar)
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

                var pessoaCadastrarDto = _mapper.Map<PessoaCadastrarDTO>(pessoaCadastrar);

                var retorno = await _pessoaService.Cadastrar(pessoaCadastrarDto);

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

        [HttpPut("/api/atualizar/pessoa/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaAtualizarDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]

        public async Task<IActionResult> AtualizarPessoa(PessoaAtualizarDTO pessoaAtualizar, int id)
        {
            try
            {
                var buscaPessoa = await _pessoaService.BuscarPorId(id);

                if (buscaPessoa == null)
                    return NotFoundResponse();

                var pessoaAtualizarDto = _mapper.Map<PessoaAtualizarDTO>(pessoaAtualizar);

                var retorno = await _pessoaService.Atualizar(pessoaAtualizarDto, id);

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

        [HttpDelete("/api/deletar/pessoa/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]

        public async Task<IActionResult> DeletarPessoa(int id)
        {
            try
            {
                var retorno = await _pessoaService.Excluir(id);

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
