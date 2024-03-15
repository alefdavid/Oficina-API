namespace Oficina.API.Responses
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

        public const string ERRO_PARAMETRO_INVALIDO = "O parâmetro informado é inválido";
        public const string ERRO_CONEXAO_BANCO_DE_DADOS = "Erro de conexão com o banco de dados";
        public const string ERRO_TIMEOUT = "Timeout";
        public const string ERRO_INESPERADO = "Erro Inesperado";
    }
}
