using FluentValidation;
using SGC.Business.Models.Entidades;

namespace SGC.Business.Models.Validacoes
{
    public class PerguntaValidation : AbstractValidator<Pergunta>
    {
        public PerguntaValidation()
        {
            RuleFor(f => f.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(6, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength) e {MaxLength} caracteres");
        }
    }
}