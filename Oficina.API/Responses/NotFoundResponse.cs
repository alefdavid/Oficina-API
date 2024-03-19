namespace OficinaOS.API.Responses
{
    public class NotFoundResponse
    {
        public NotFoundResponse()
        {
            this.Mensagem = $"Nenhum informação foi encontrada.";
        }

        public NotFoundResponse(string objeto)
        {
            this.Mensagem = $"Nenhum informação de {objeto} foi encontrada.";
        }

        public string Mensagem { get; private set; }
    }
}
