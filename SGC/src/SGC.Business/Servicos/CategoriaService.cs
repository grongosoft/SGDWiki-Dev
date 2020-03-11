using SGC.Business.Interfaces;
using SGC.Business.Models.Entidades;
using System.Threading.Tasks;

namespace SGC.Business.Servicos
{
    public class CategoriaService : BaseService, ICategoriaService
    {
        #region Private Fields

        private readonly ICategoriaRepository _categoriaRepository;

        #endregion Private Fields

        #region Public Constructors

        public CategoriaService(ICategoriaRepository categoriaRepository, INotificador notificador) : base(notificador)
        {
            _categoriaRepository = categoriaRepository;
        }

        #endregion Public Constructors

        #region Public Methods


        //TODO: IMPLEMENTAR METODOS!
        public Task Atualizar(Categoria categoria)
        {
            throw new System.NotImplementedException();
        }

        public Task Criar(Categoria categoria)
        {
            throw new System.NotImplementedException();
        }

        public Task Remover(long Id)
        {
            throw new System.NotImplementedException();
        }

        #endregion Public Methods
    }
}