using System.Collections.Generic;
using SGC.Common.Enum;

namespace SGD.App.ViewModel
{
    public class PerguntaRespostaViewModel
    {
        public ELike Like { get; set; }

        public List<CategoriaViewModel> CategoriaViewModel { get; set; }
        public PerguntaViewModel PerguntaViewModel { get; set; }
        public RespostaViewModel RespostaViewModel { get; set; }
    }
}