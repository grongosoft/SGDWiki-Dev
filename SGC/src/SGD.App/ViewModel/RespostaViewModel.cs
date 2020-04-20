using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SGD.App.ViewModel
{
    public class RespostaViewModel
    {
        #region Public Properties

        [Required(ErrorMessage = "O Campo Resposta é de preenchimento obrigatório!")]
        [StringLength(4000, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 6)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Key]
        [DisplayName("Código")]
        public long Id { get; set; }

        /*EF RELATION*/

        [HiddenInput]
        public long PerguntaId { get; set; }

        #endregion Public Properties
    }
}