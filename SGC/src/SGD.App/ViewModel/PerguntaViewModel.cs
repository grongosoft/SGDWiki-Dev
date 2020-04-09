using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SGD.App.ViewModel
{
    public class PerguntaViewModel
    {
        [Key]
        [DisplayName("Código")]
        public long? Id { get; set; }
        
        [Required(ErrorMessage = "O Campo Categoria é de preenchimento obrigatório!")]
        public long CategoriaId { get; set; }

        [Required(ErrorMessage = "O Campo {0} é de preenchimento obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 6)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        public string OperadorId { get; set; }

        public RespostaViewModel Resposta { get; set; }

        //public List<CategoriaViewModel> CategoriasViewModel { get; set; }
        //[Required(ErrorMessage = "O Campo Categoria é de preenchimento obrigatório!")]

        public SelectList CategoriasList { get; set; }

        
    }
}