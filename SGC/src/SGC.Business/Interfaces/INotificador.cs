using SGC.Business.Notificacoes;
using System.Collections.Generic;

namespace SGC.Business.Interfaces
{
    public interface INotificador
    {
        #region Public Methods

        void Handle(Notificacao notificacao);

        List<Notificacao> ObterNotificacoes();

        bool TemNotificacao();

        #endregion Public Methods
    }
}