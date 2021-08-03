using AutoMapper;
using DevIO.Domain.Intefaces;
using DevIO.Domain.Interfaces;
using DevIO.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteProgramacao.ViewModels;

namespace TesteProgramacao.Controllers
{
    public class LivroController : BaseController
    {
        private readonly ILivroRepository _livroRepository;
        private readonly ILivroService _livroService;
        private readonly IMapper _mapper;

        public LivroController(ILivroRepository livroRepository,
                                      IMapper mapper,
                                      ILivroService livroService,
                                      INotificador notificador) : base(notificador)
        {
            _livroRepository = livroRepository;
            _mapper = mapper;
            _livroService = livroService;
        }
        [Route("lista-de-livros")]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<LivroViewModels>>(await _livroRepository.ObterTodos()));
        }

        [Route("dados-do-fornecedor/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var fornecedorViewModel = await ObterLivrosAutor(id);

            if (fornecedorViewModel == null)
            {
                return NotFound();
            }

            return View(fornecedorViewModel);
        }

        [Route("nova-editora")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("novo-editora")]
        [HttpPost]
        public async Task<IActionResult> Create(LivroViewModels livroViewModel)
        {
            if (!ModelState.IsValid) return View(livroViewModel);

            var livro = _mapper.Map<Livro>(livroViewModel);
            await _livroService.Adicionar(livro);

            if (!OperacaoValida()) return View(livroViewModel);

            return RedirectToAction("Index");
        }

        [Route("editar-fornecedor/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var livroViewModel = await ObterEditorasAutorLivro(id);

            if (livroViewModel == null)
            {
                return NotFound();
            }

            return View(livroViewModel);
        }

        [Route("editar-fornecedor/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, LivroViewModels livroViewModel)
        {
            if (id != livroViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(livroViewModel);

            var livro = _mapper.Map<Livro>(livroViewModel);
            await _livroService.Atualizar(livro);

            if (!OperacaoValida()) return View(await ObterEditorasAutorLivro(id));

            return RedirectToAction("Index");
        }

        [Route("excluir-fornecedor/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var livroViewModel = await ObterLivro(id);

            if (livroViewModel == null)
            {
                return NotFound();
            }

            return View(livroViewModel);
        }

        [Route("excluir-livro/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var livro = await ObterLivro(id);

            if (livro == null) return NotFound();

            await _livroService.Remover(id);

            if (!OperacaoValida()) return View(livro);

            return RedirectToAction("Index");
        }

        [Route("obter-autor-Livro/{id:guid}")]
        public async Task<IActionResult> ObterLivro(Guid id)
        {
            var livro = await ObterLivrosAutor(id);

            if (livro == null)
            {
                return NotFound();
            }

            return PartialView("_DetalhesAutor", livro);
        }

      

        private async Task<LivroViewModels> ObterLivrosAutor(Guid id)
        {
            return _mapper.Map<LivroViewModels>(await _livroRepository.ObterAutorPorLivro(id));
        }

        private async Task<LivroViewModels> ObterEditorasAutorLivro(Guid id)
        {
            return _mapper.Map<LivroViewModels>(await _livroRepository.ObterEditorasAutorLivro(id));
        }

    }
}
