using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SGD.App.ViewModel
{
    public class CategoriaViewModel
    {
        [Key]
        [DisplayName("Código")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é de preenchimento obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 6)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Campo {0} é de preenchimento obrigatório!")]
        [StringLength(20, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 6)]
        public string Nome { get; set; }
        public string OperadorId { get; set; }

        [HiddenInput]
        [DisplayName("Nome do Operador")]
        public string NomeOperador { get; set; }

    }
}