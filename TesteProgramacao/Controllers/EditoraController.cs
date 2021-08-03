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
    public class EditoraController : BaseController
    {
        private readonly IEditoraRepository _editoraRepository;
        private readonly ILivroRepository _livroRepository;
        private readonly IEditoraService _editoraService;
        private readonly IMapper _mapper;

        public EditoraController(INotificador notificador,
                                  IEditoraRepository editoraRepository,
                                  IEditoraService editoraService,
                                  ILivroRepository livroRepository,
                                  IMapper mapper) : base(notificador)
        {
            _editoraRepository = editoraRepository;
            _editoraService = editoraService;
            _livroRepository = livroRepository;
            _mapper = mapper;

        }

        public async Task<IActionResult> IndexAsync()
        {
            return View(_mapper.Map<IEnumerable<EditoraViewModels>>(await _editoraRepository.ObterEditorasLivros()));
        }

        [Route("dados-do-produto/{id:guid}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var produtoViewModel = await ObterEditora(id);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [Route("nova-editora")]
        public async Task<IActionResult> Create()
        {
            var editoraViewModel = await PopularEditora(new EditoraViewModels());

            return View(editoraViewModel);
        }

        [Route("novo-editora")]
        [HttpPost]
        public async Task<IActionResult> Create(EditoraViewModels editoraViewModel)
        {
            editoraViewModel = await PopularEditora(editoraViewModel);
            if (!ModelState.IsValid) return View(editoraViewModel);

            await _editoraService.Adicionar(_mapper.Map<Editora>(editoraViewModel));

            if (!OperacaoValida()) return View(editoraViewModel);

            return RedirectToAction("Index");
        }

        [Route("editar-editora/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var editoraViewModel = await ObterEditora(id);

            if (editoraViewModel == null)
            {
                return NotFound();
            }

            return View(editoraViewModel);
        }

        [Route("editar-editora/{id:guid}")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, EditoraViewModels editoraViewModel)
        {
            if (id != editoraViewModel.Id) return NotFound();

            var editoraAtualizacao = await ObterEditora(id);        

            editoraAtualizacao.Nome = editoraViewModel.Nome;
            editoraAtualizacao.Cnpj = editoraViewModel.Cnpj;
            editoraAtualizacao.Endereco = editoraViewModel.Endereco;

            await _editoraService.Atualizar(_mapper.Map<Editora>(editoraAtualizacao));

            if (!OperacaoValida()) return View(editoraViewModel);

            return RedirectToAction("Index");
        }

        [Route("excluir-editora/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var editora = await ObterEditora(id);

            if (editora == null)
            {
                return NotFound();
            }

            return View(editora);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var editora = await ObterEditora(id);

            if (editora == null)
            {
                return NotFound();
            }

            await _editoraService.Remover(id);

            if (!OperacaoValida()) return View(editora);

            TempData["Sucesso"] = "Produto excluido com sucesso!";

            return RedirectToAction("Index");
        }

        private async Task<EditoraViewModels> ObterEditora(Guid id)
        {
            var editora = _mapper.Map<EditoraViewModels>(await _editoraRepository.ObterEditorasLivros());
            editora.Livros = (IList<LivroViewModels>)_mapper.Map<IEnumerable<EditoraViewModels>>(await _editoraRepository.ObterTodos());
            return editora;
        }

        private async Task<EditoraViewModels> PopularEditora(EditoraViewModels editora)
        {
            editora.Livros = (IList<LivroViewModels>)_mapper.Map<IEnumerable<LivroViewModels>>(await _livroRepository.ObterTodos());
            return editora;
        }

       
    }
}
