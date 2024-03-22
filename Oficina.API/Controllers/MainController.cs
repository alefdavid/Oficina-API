using Microsoft.AspNetCore.Mvc;
using OficinaOS.API.Responses;
using OficinaOS.Domain.Communication;

namespace OficinaOS.API.Controllers
{
    [Controller]
    public class MainController : ControllerBase
    {
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
