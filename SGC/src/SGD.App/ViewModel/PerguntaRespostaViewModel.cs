using Microsoft.AspNetCore.Mvc.Rendering;
using SGC.Common.Enum;
using System.Collections.Generic;

namespace SGD.App.ViewModel
{
    public class PerguntaRespostaViewModel
    {
        #region Public Properties

        public long? CategoriaId { get; set; }

        public SelectList CategoriasList { get; set; }

        public List<CategoriaViewModel> CategoriaViewModel { get; set; }

        public string DescricaoCategoria { get; set; }

        public string DescricaoPergunta { get; set; }

        public string DescricaoResposta { get; set; }

        public string EmailOperador { get; set; }

        public long? IdSelecionado { get; set; }

        public ELike Like { get; set; }

        public string OperadorId { get; set; }

        public long? PerguntaId { get; set; }

        #endregion Public Properties
    }
}