using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SGD.App.ViewModel
{
    public class RespostaViewModel
    {
        [Key]
        [DisplayName("Código")]
        public long Id { get; set; }
       
        [Required(ErrorMessage = "O Campo {0} é de preenchimento obrigatório!")]
        [StringLength(4000, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 6)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }
        /*EF RELATION*/
        [HiddenInput]
        public long PerguntaId { get; set; }
    }
}