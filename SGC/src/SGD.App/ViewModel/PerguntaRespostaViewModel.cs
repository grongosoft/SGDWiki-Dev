using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGC.Common.Enum;

namespace SGD.App.ViewModel
{
    public class PerguntaRespostaViewModel
    {
        public ELike Like { get; set; }

        public List<CategoriaViewModel> CategoriaViewModel { get; set; }
        //public PerguntaViewModel PerguntaViewModel { get; set; }
        //public RespostaViewModel RespostaViewModel { get; set; }

        public long? PerguntaId { get; set; }
        public string DescricaoPergunta { get; set; }
        public string DescricaoResposta { get; set; }
        public string OperadorId { get; set; }

        public long? IdSelecionado { get; set; }
        public SelectList CategoriasList { get; set; }
        public long? CategoriaId { get; set; }
        public string DescricaoCategoria { get; set; }

    }
}