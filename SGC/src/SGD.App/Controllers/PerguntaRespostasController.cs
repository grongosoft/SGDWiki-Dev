using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGC.Business.Interfaces;
using SGC.Data.Contexto;
using SGD.App.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SGD.App.Controllers
{
    public class PerguntaRespostasController : Controller
    {
        #region Private Fields

        private readonly ICategoriaRepository _categoriaRepository;
        private readonly DataContext _context;
        private readonly IPerguntaRepository _perguntaRepository;
        private readonly IPerguntaService _perguntaService;
        private readonly IRespostaRepository _respostaRepository;
        private readonly IRespostaService _respostaService;

        #endregion Private Fields

        #region Public Constructors

        public PerguntaRespostasController(DataContext context, ICategoriaRepository categoriaRepository, ICategoriaService categoriaService,
            IPerguntaService perguntaService, IRespostaService respostaService, IPerguntaRepository perguntaRepository, IRespostaRepository respostaRepository)
        {
            _context = context;
            _categoriaRepository = categoriaRepository;

            _perguntaService = perguntaService;
            _perguntaRepository = perguntaRepository;
            _respostaService = respostaService;
            _respostaRepository = respostaRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        [Route("filtro-pergunta_resposta")]
        public IActionResult Index()
        {
            var categoriasViewModel = BuscarCategoriasCadastradas();
            var perguntasRespostaViewModel = new List<PerguntaRespostaViewModel>();

            var perguntaRespostaViewModel = new PerguntaRespostaViewModel
            {
                CategoriasList = new SelectList(categoriasViewModel.Result, "Id", "Nome")
            };

            perguntasRespostaViewModel.Add(perguntaRespostaViewModel);

            //if (perguntaRepostaViewModel.Result.CategoriaViewModel == null)
            //    return RedirectToAction("Index");

            return View(perguntasRespostaViewModel);
        }

        [Route("Pesquisar/{id:long?}")]
        public IActionResult Pesquisar(long? id)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction(nameof(Index));
            }

            var categoriasViewModel = BuscarCategoriasCadastradas();

            var perguntasRespostas = new List<PerguntaRespostaViewModel>();

            var perguntas = _perguntaRepository.Listar();

            foreach (var pergunta in perguntas.Result)
            {
                var categoria = _categoriaRepository.ObterCategoriaPorId(pergunta.CategoriaId).Result;

                var perguntaResposta = new PerguntaRespostaViewModel
                {
                    PerguntaId = pergunta.Id,
                    DescricaoPergunta = pergunta.Descricao,
                    OperadorId = pergunta.OperadorId,
                    IdSelecionado = id,
                    CategoriasList = new SelectList(categoriasViewModel.Result, "Id", "Nome"),
                    DescricaoCategoria = categoria.Descricao

                };

                perguntasRespostas.Add(perguntaResposta);
            }

            if (id != null && id > 0)
            {
                if (perguntasRespostas.Any(e => e.PerguntaId == id))
                {
                    var pergunta = _perguntaRepository.ObterPerguntaPorId(id.Value).Result;
                    var categoria = _categoriaRepository.ObterCategoriaPorId(pergunta.CategoriaId).Result;


                    var resposta = _respostaRepository.ObterRespostaPorPergunta(id.Value).Result;
                    var perguntaRespostaRemove = perguntasRespostas.FirstOrDefault(p => p.PerguntaId == id);

                    var perguntaRespostaRenew = new PerguntaRespostaViewModel
                    {
                        PerguntaId = perguntaRespostaRemove.PerguntaId,
                        DescricaoPergunta = perguntaRespostaRemove.DescricaoPergunta,
                        OperadorId = perguntaRespostaRemove.OperadorId,
                        DescricaoResposta = resposta.Descricao,
                        CategoriasList = new SelectList(categoriasViewModel.Result, "Id", "Nome"),
                        DescricaoCategoria = categoria.Descricao

                    };

                    perguntasRespostas.Remove(perguntaRespostaRemove);

                    perguntasRespostas.Add(perguntaRespostaRenew);
                }
            }

            return View("Index", perguntasRespostas);

            //if (!ModelState.IsValid)
            //    RedirectToAction(nameof(Index));
            // return View(perguntaRespostaViewModel);
            return RedirectToAction(nameof(Index));
        }

        #endregion Public Methods

        #region Private Methods

        private async Task<List<CategoriaViewModel>> BuscarCategoriasCadastradas()
        {
            var categoriasViewModel = new List<CategoriaViewModel>();
            var categorias = await _categoriaRepository.Listar();

            foreach (var categoria in categorias)
            {
                var categoriaViewModel = new CategoriaViewModel
                {
                    Nome = categoria.Nome,
                    Id = categoria.Id
                };

                categoriasViewModel.Add(categoriaViewModel);
            }

            return categoriasViewModel;
        }

        #endregion Private Methods
    }
}