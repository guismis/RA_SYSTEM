using DevIO.Domain.Intefaces;
using DevIO.Domain.Interfaces;
using DevIO.Domain.Models;
using DevIO.Domain.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Domain.Services
{
    public class EditoraService : BaseService, IEditoraService
    {
        private readonly IEditoraRepository _editoraRepository;
        private readonly ILivroRepository _livroRepository;

        public EditoraService(IEditoraRepository editoraRepository, 
                                ILivroRepository livroRepository,
                              INotificador notificador) : base(notificador)
        {
            _editoraRepository = editoraRepository;
            _livroRepository = livroRepository;
        }

        public async Task<bool> Adicionar(Editora editora)
        {
            if(!ExecutarValidacao(new EditoraValidations(), editora))
            {
                return false;

            }

            if (_livroRepository.Buscar(f => f.Editora.Nome == editora.Nome).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado.");
                return false;
            }

            await _editoraRepository.Adicionar(editora);
            return true;
        }

        public async Task<bool> Atualizar(Editora editora)
        {

            if (!ExecutarValidacao(new EditoraValidations(), editora)) return false;

            if (_livroRepository.Buscar(f => f.Editora.Cnpj == editora.Cnpj && f.Id != editora.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return false;
            }

            await _editoraRepository.Atualizar(editora);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_editoraRepository.ObterAutorPorEditora(id).Result.Livros.Any() || _livroRepository.ObterEditorasAutorLivro(id).Result.Editora.Livros.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return false;
            }

            var editora = await _editoraRepository.ObterAutorPorEditora(id);

            if (editora != null)
            {
                await _livroRepository.Remover(editora.Id);
            }

            await _editoraRepository.Remover(id);
            return true;
        }

        public void Dispose()
        {
            _editoraRepository?.Dispose();
        }
    }
}
