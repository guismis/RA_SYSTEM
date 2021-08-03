using AutoMapper;
using DevIO.Domain.Data.Repository;
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
    public class AutorController : BaseController
    {
        private readonly IAutorRepository _autorRepository;
        private readonly ILivroRepository _livroRepository;
        private readonly IAutorService _autorService;
        private readonly IMapper _mapper;

        public AutorController(INotificador notificador,
                                  IAutorRepository autorRepository,
                                  IAutorService autorService,
                                  IMapper mapper) : base(notificador)
        {
            _autorRepository = autorRepository;
            _autorService = autorService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexAsyn()
        {
            return View(_mapper.Map<IEnumerable<AutorViewModels>>(await _autorRepository.ObterAutorLivros()));
        }

        [Route("lista-de-autores")]
        public async Task<ActionResult<AutorViewModels>> ObterPorId(Guid id)
        {
            var autorViewModel = await ObterAutor(id);

            if (autorViewModel == null) return NotFound();

            return View(autorViewModel);
        }

        private async Task<AutorViewModels> ObterAutor(Guid id)
        {
            return _mapper.Map<AutorViewModels>(await _autorRepository.ObterAutorPorLivro(id));
        }

 
        [Route("dados-do-autores/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var autorViewModel = await ObterAutor(id);

            if (autorViewModel == null)
            {
                return NotFound();
            }

            return View(autorViewModel);
        }

        [Route("novo-autor")]
        public async Task<IActionResult> Create()
        {
            var autorViewModel = await PopularAutores(new AutorViewModels());

            return View(autorViewModel);
        }

        [Route("novo-autor")]
        [HttpPost]
        public async Task<IActionResult> Create(AutorViewModels autorViewModel)
        {
            autorViewModel = await PopularAutores(autorViewModel);
            if (!ModelState.IsValid) return View(autorViewModel);

            

            if (!OperacaoValida()) return View(autorViewModel);

            return RedirectToAction("Index");
        }

        [Route("editar-autor/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var autorViewModel = await ObterAutor(id);

            if (autorViewModel == null)
            {
                return NotFound();
            }

            return View(autorViewModel);
        }

        [Route("editar-autor/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, AutorViewModels autorViewModel)
        {
            if (id != autorViewModel.Id) return NotFound();

            var autorAtualizacao = await ObterAutor(id);
            autorAtualizacao.Nome = autorViewModel.Nome;
            autorAtualizacao.Cpf = autorViewModel.Cpf;
            autorAtualizacao.Celular = autorViewModel.Celular;
            autorAtualizacao.Email = autorViewModel.Email;

            await _autorService.Atualizar(_mapper.Map<Autor>(autorAtualizacao));

            if (!OperacaoValida()) return View(autorViewModel);

            return RedirectToAction("Index");
        }

        [Route("excluir-autor/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var autor = await ObterAutor(id);

            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

       
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var autor = await ObterAutor(id);

            if (autor == null)
            {
                return NotFound();
            }

            await _autorService.Remover(id);

            if (!OperacaoValida()) return View(autor);

            TempData["Sucesso"] = "Produto excluido com sucesso!";

            return RedirectToAction("Index");
        }

       

        private async Task<AutorViewModels> PopularAutores(AutorViewModels autor)
        {
            autor.Livros = (IList<LivroViewModels>)_mapper.Map<IEnumerable<AutorViewModels>>(await _autorRepository.ObterTodos());
            return autor;
        }

       

    }
}
