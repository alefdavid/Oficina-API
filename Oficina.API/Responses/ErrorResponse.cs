namespace OficinaOS.API.Responses
{
    public class ErrorResponse
    {
        public ErrorResponse(string mensagem)
        {
            if (!string.IsNullOrEmpty(mensagem))            
                this.MensagensErro = new string[1] { mensagem };
        }

        public ErrorResponse(IList<string> mensagens)
        {
            if (mensagens != null && mensagens.Count > 0)
                this.MensagensErro = mensagens.ToArray();
        }

        public string[] MensagensErro { get; private set; }
    }

    public class MensagemErro
    {
        private MensagemErro() { }

        public const string Erro_Parametro_Invalido = "O parâmetro informado é inválido";      
        public const string Erro_Inesperado = "Erro Inesperado";
    }
}
