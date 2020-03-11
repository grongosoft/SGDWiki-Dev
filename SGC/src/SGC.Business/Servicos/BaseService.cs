using FluentValidation;
using FluentValidation.Results;
using SGC.Business.Interfaces;
using SGC.Business.Models.Entidades;
using SGC.Business.Notificacoes;

namespace SGC.Business.Servicos
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;
        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TValidation, TEntity>(TValidation validacao, TEntity entidade)
            where TValidation : AbstractValidator<TEntity> where TEntity : Entity
        {
            var validar = validacao.Validate(entidade);

            if (validar.IsValid)
                return true;

            Notificar(validar);
            
            return false;
        }
    }
}