using FluentValidation;
using SGC.Business.Models.Entidades;

namespace SGC.Business.Models.Validacoes
{
    public class CategoriaValidation : AbstractValidator<Categoria>
    {
        #region Public Constructors

        public CategoriaValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido!")
                .Length(6, 20).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres!");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser preenchido!")
                .Length(6, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres!");
        }

        #endregion Public Constructors
    }
}