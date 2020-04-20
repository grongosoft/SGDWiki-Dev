using SGC.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SGC.Business.Notificacoes
{
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;
        public void Handle(Notificacao notificacao)
        {
            _notificacoes = new List<Notificacao>();
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}