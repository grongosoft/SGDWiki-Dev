using System.Threading.Tasks;
using SGC.Business.Interfaces;
using SGC.Business.Models.Entidades;

namespace SGC.Business.Servicos
{
    public class RespostaService : BaseService, IRespostaService
    {
        private readonly IRespostaRepository _respostaRepository;
        public RespostaService(IRespostaRepository respostaRepository, INotificador notificador) : base(notificador)
        {
            _respostaRepository = respostaRepository;
        }

        public void Dispose()
        {
            _respostaRepository?.Dispose();
        }

        public Task Adicionar(Resposta resposta)
        {
            throw new System.NotImplementedException();
        }

        public Task Atualizar(Resposta resposta)
        {
            throw new System.NotImplementedException();
        }

        public Task Remover(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}