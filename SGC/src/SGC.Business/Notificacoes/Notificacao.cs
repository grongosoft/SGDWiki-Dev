namespace SGC.Business.Notificacoes
{
    public class Notificacao
    {
        #region Public Constructors

        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        #endregion Public Constructors

        #region Public Properties

        public string Mensagem { get; }

        #endregion Public Properties
    }
}