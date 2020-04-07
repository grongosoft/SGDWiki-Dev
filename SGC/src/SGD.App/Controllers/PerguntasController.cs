using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGC.Business.Interfaces;
using SGC.Business.Models.Entidades;
using SGC.Data.Contexto;
using SGD.App.Extensoes;
using SGD.App.ViewModel;

namespace SGD.App.Controllers
{
    [Authorize]
    public class PerguntasController : Controller
    {
        private readonly DataContext _context;
        private readonly ICustomUser _customUsers;
        private ICategoriaRepository _categoriaRepository;
        private IPerguntaService _perguntaService;
        private IMapper _mapper;



        public PerguntasController(DataContext context, ICustomUser customUsers, ICategoriaRepository categoriaRepository, IPerguntaService perguntaService, IMapper mapper)
        {
            _context = context;
            _customUsers = customUsers;
            _categoriaRepository = categoriaRepository;
            _perguntaService = perguntaService;
            _mapper = mapper;
        }

        [Route("perguntaxresposta")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Perguntas.ToListAsync());
        }

        [Route("perguntaxresposta")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pergunta == null)
            {
                return NotFound();
            }

            return View(pergunta);
        }


        [Route("nova-pergunta_resposta")]
        public IActionResult Create()
        {
            var categoriasViewModel = BuscarCategoriasCadastradas();
            var perguntaViewModel = new PerguntaViewModel

            {
                CategoriasList = new SelectList(categoriasViewModel.Result, "Id", "Nome")
            };

            return View(perguntaViewModel);
        }


        [HttpPost]
        [Route("nova-pergunta_resposta")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PerguntaViewModel perguntaViewModel)
        {


            if (!ModelState.IsValid)
            {
                return View(perguntaViewModel);

            }

            perguntaViewModel.OperadorId = _customUsers.ObterUsuarioLogado();
           
            //TODO:CRIAR OPERAÇÃO VÁLIDA!
            var pergunta = _mapper.Map<Pergunta>(perguntaViewModel);
            await _perguntaService.Adicionar(pergunta);
        



            TempData["Success"] = "Pergunta x Resposta Cadastrada com sucesso!";

            return View("Index");
        }

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

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas.FindAsync(id);
            if (pergunta == null)
            {
                return NotFound();
            }
            return View(pergunta);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Descricao,OperadorId,Id")] Pergunta pergunta)
        {
            if (id != pergunta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pergunta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PerguntaExists(pergunta.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pergunta);
        }


        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pergunta = await _context.Perguntas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pergunta == null)
            {
                return NotFound();
            }

            return View(pergunta);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var pergunta = await _context.Perguntas.FindAsync(id);
            _context.Perguntas.Remove(pergunta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PerguntaExists(long id)
        {
            return _context.Perguntas.Any(e => e.Id == id);
        }
    }
}
