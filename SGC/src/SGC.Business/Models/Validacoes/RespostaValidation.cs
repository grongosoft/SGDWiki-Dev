using FluentValidation;
using SGC.Business.Models.Entidades;

namespace SGC.Business.Models.Validacoes
{
    public class RespostaValidation : AbstractValidator<Resposta>
    {
        #region Public Constructors

        public RespostaValidation()
        {
            RuleFor(r => r.Descricao)
                .NotEmpty()
                .WithMessage("O campo {PropertyName} precisa ser preenchido!")
                .Length(6, 4000)
                .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres!");
        }

        #endregion Public Constructors
    }
}