using DevIO.Domain.Data.Repository;
using DevIO.Domain.Intefaces;
using DevIO.Domain.Interfaces;
using DevIO.Domain.Models;
using DevIO.Domain.Models.Validations;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Domain.Services
{
    public class LivroServise : BaseService, ILivroService
    {
        private readonly ILivroRepository _livroRepository;
        private readonly IEditoraRepository _editoraRepository;
        private readonly IAutorRepository _autorRepository;

        public LivroServise(ILivroRepository livroRepository,
                            IEditoraRepository editoraRepository,
                            IAutorRepository autorRepository,
                              INotificador notificador) : base(notificador)
        {
            _livroRepository = livroRepository;
            _editoraRepository = editoraRepository;
            _autorRepository = autorRepository;
        }

        public async Task<bool> Adicionar(Livro livro)
        {
            if (!ExecutarValidacao(new LivroValidations(), livro)
                || !ExecutarValidacao(new EditoraValidations(), livro.Editora)
                || !ExecutarValidacao(new AutorValidations(), livro.Autor)) return false;

            if (_livroRepository.Buscar(f => f.NomeDoLivro == livro.NomeDoLivro).Result.Any())
            {
                await _livroRepository.Adicionar(livro);
                return true;
            }
            Notificar("Já existe um fornecedor com este documento informado.");
            return false;
        }

        public async Task<bool> Atualizar(Livro livro)
        {

            if (!ExecutarValidacao(new LivroValidations(), livro)) return false;

            if (_livroRepository.Buscar(f => f.Autor.Cpf == livro.Autor.Cpf && f.Id != livro.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return false;
            }

            await _livroRepository.Atualizar(livro);
            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_livroRepository.ObterEditorasAutorLivro(id).Result.Autor.Livros.Any() || _livroRepository.ObterEditorasAutorLivro(id).Result.Editora.Livros.Any())
            {
                Notificar("O fornecedor possui produtos cadastrados!");
                return false;
            }

            var livraria = await _livroRepository.ObterEditorasAutorLivro(id);

            if (livraria != null)
            {
                await _livroRepository.Remover(livraria.Id);
            }

            await _livroRepository.Remover(id);
            return true;
        }
    }
}
