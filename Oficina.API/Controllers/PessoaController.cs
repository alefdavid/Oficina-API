using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OficinaOS.API.Responses;
using OficinaOS.Domain.DTO;
using OficinaOS.Domain.Entities;
using OficinaOS.Domain.Interfaces.Services;

namespace OficinaOS.API.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var retorno = await _pessoaService.GetById(id);

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

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var retorno = await _pessoaService.GetAll();

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

        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaCadastrarDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]

        public async Task<IActionResult> Post([FromBody] PessoaCadastrarDTO pessoaCadastrar)
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

                var retorno = await _pessoaService.Post(pessoaCadastrarDto);

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

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PessoaAtualizarDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]

        public async Task<IActionResult> Put(PessoaAtualizarDTO pessoaAtualizar, int id)
        {
            try
            {
                var buscaPessoa = await _pessoaService.GetById(id);

                if (buscaPessoa == null)
                    return NotFoundResponse();

                var pessoaAtualizarDto = _mapper.Map<PessoaAtualizarDTO>(pessoaAtualizar);

                var retorno = await _pessoaService.Put(pessoaAtualizarDto, id);

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

        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var retorno = await _pessoaService.Delete(id);

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
