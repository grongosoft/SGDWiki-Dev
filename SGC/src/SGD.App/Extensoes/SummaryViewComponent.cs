using Microsoft.AspNetCore.Mvc;
using SGC.Business.Interfaces;
using System.Threading.Tasks;

namespace SGD.App.Extensoes
{
    public class SummaryViewComponent : ViewComponent
    {
        #region Private Fields

        private readonly INotificador _notificador;

        #endregion Private Fields

        #region Public Constructors

        public SummaryViewComponent(INotificador notificador)
        {
            _notificador = notificador;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificador.ObterNotificacoes());

            notificacoes.ForEach(n => ViewData.ModelState.AddModelError(string.Empty, n.Mensagem));

            return View();
        }

        #endregion Public Methods
    }
}