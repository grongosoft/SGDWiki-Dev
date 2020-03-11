using SGC.Business.Notificacoes;
using System.Collections.Generic;

namespace SGC.Business.Interfaces
{
    public interface INotificador
    {
        #region Public Methods

        bool ExisteNotificacao();

        void Handle(Notificacao notificacao);

        List<Notificacao> ObterNotificacoes();

        #endregion Public Methods
    }
}