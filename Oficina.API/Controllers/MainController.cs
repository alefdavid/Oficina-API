using Microsoft.AspNetCore.Mvc;
using Oficina.API.Responses;
using Oficina.Domain.Communication;

namespace Oficina.API.Controllers
{
    [Controller]
    public class MainController : ControllerBase
    {
        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if (resposta != null && resposta.Errors.Mensagens.Any())
            {
                foreach (var mensagem in resposta.Errors.Mensagens)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }

                return true;
            }

            return false;
        }

        protected void AdicionarErroValidacao(string mensagem)
        {
            ModelState.AddModelError(string.Empty, mensagem);
        }

        protected bool OperacaoValida()
        {
            return ModelState.ErrorCount == 0;
        }

        [NonAction]
        public NotFoundObjectResult NotFoundResponse(string? objeto = null) =>
            string.IsNullOrEmpty(objeto) ?
                NotFound(new NotFoundResponse()) :
                NotFound(new NotFoundResponse(objeto));

        [NonAction]
        public BadRequestObjectResult BadResponse(string mensagem) =>
            BadRequest(new ErrorResponse(mensagem));

        [NonAction]
        public BadRequestObjectResult BadResponse(List<string> mensagens) =>
            BadRequest(new ErrorResponse(mensagens));

        [NonAction]
        public void ShowConsoleError(Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);

            if (ex.InnerException != null)
            {
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.InnerException.StackTrace);
            }
        }
    }
}
