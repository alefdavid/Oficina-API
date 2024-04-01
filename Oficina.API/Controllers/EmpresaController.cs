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
    public class EmpresaController : MainController
    {
        private readonly IEmpresaService _empresaService;

        private readonly IMapper _mapper;

        public EmpresaController(IEmpresaService empresaService,
                                IMapper mapper)
        {
            _empresaService = empresaService;
            _mapper = mapper;
        }

        [HttpGet("{cnpj}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpresaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]
        public async Task<IActionResult> GetByCnpj(string cnpj)
        {
            try
            {
                var retorno = await _empresaService.GetByCnpj(cnpj);

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpresaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var retorno = await _empresaService.GetAll();

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpresaCadastrarDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]

        public async Task<IActionResult> Post([FromBody] EmpresaCadastrarDTO empresaCadastrar)
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

                var empresaCadastrarDto = _mapper.Map<EmpresaCadastrarDTO>(empresaCadastrar);

                var retorno = await _empresaService.Post(empresaCadastrarDto);

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpresaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(NotFoundResponse))]

        public async Task<IActionResult> Put(EmpresaAtualizarDTO empresaAtualizar, int id)
        {
            try
            {
                var buscaEmpresa = await _empresaService.GetById(id);

                if (buscaEmpresa == null)
                    return NotFoundResponse();

                var empresaAtualizarDto = _mapper.Map<EmpresaAtualizarDTO>(empresaAtualizar);

                var retorno = await _empresaService.Put(empresaAtualizarDto, id);

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
                var retorno = await _empresaService.Delete(id);

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
