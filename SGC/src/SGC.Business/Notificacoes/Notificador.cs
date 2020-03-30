using SGC.Business.Interfaces;
using System.Collections.Generic;

namespace SGC.Business.Notificacoes
{
    public class Notificador : INotificador
    {
        public void Handle(Notificacao notificacao)
        {
            throw new System.NotImplementedException();
        }

        public List<Notificacao> ObterNotificacoes()
        {
            throw new System.NotImplementedException();
        }

        public bool TemNotificacao()
        {
            throw new System.NotImplementedException();
        }
    }
}