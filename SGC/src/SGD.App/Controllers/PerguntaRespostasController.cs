using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SGC.Business.Interfaces;
using SGC.Data.Contexto;
using SGD.App.ViewModel;

namespace SGD.App.Controllers
{
    public class PerguntaRespostasController : Controller
    {
        private readonly DataContext _context;
        private readonly ICategoriaRepository _categoriaRepository;

        public PerguntaRespostasController(DataContext context, ICategoriaRepository categoriaRepository)
        {
            _context = context;
            _categoriaRepository = categoriaRepository;

        }

        [Route("filtro-pergunta_resposta")]
        public IActionResult Index()
        {
            var perguntaRepostaViewModel = BuscarCategoriasCadastradas();

            if (perguntaRepostaViewModel.Result.CategoriaViewModel == null)
                return RedirectToAction("Index");

            return View(perguntaRepostaViewModel.Result);
        }


        private async Task<PerguntaRespostaViewModel> BuscarCategoriasCadastradas()
        {
            var categoriaUsuario = new List<CategoriaViewModel>();
            var categorias = await _categoriaRepository.Listar();

            var perguntaRepostaViewModel = new PerguntaRespostaViewModel
            {
                CategoriaViewModel = new List<CategoriaViewModel>()
            };



            foreach (var categoria in categorias)
            {
                var categoriaViewModel = new CategoriaViewModel
                {
                    Nome = categoria.Nome,
                    Id = categoria.Id

                };

                perguntaRepostaViewModel.CategoriaViewModel.Add(categoriaViewModel);
            }


            return perguntaRepostaViewModel;

        }
    }
}