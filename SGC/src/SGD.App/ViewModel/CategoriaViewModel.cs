﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace SGD.App.ViewModel
{
    public class CategoriaViewModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "O Campo {0} é de preenchimento obrigatório!")]
        [StringLength(100, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 6)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Campo {0} é de preenchimento obrigatório!")]
        [StringLength(20, ErrorMessage = "O Campo {0} precisa ter entre {2} e {1} caracteres!", MinimumLength = 6)]
        public string Nome { get; set; }

        [HiddenInput]
        public string OperadorId { get; set; }

    }
}