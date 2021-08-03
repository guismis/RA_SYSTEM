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
    public class AutorService : BaseService, IAutorService
    {
        private readonly IAutorRepository _autorRepository;
        private readonly ILivroRepository _livroRepository;

        public AutorService(IAutorRepository autorRepository,
                             ILivroRepository livroRepository,
                              INotificador notificador) : base(notificador)
        {
            _autorRepository = autorRepository;
            _livroRepository = livroRepository;
        }

        public async Task<bool> Adiciona(Autor autor)
        {
            if (!ExecutarValidacao(new AutorValidations(), autor))
            {
                return false;

            }

            if (_livroRepository.Buscar(f => f.Autor.Nome == autor.Nome).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento informado.");
                return false;
            }

            await _autorRepository.Adicionar(autor);
            return true;
        }

        public async Task<bool> Atualizar(Autor autor)
        {
            if (!ExecutarValidacao(new AutorValidations(), autor)) return false;

            if (_autorRepository.Buscar(f => f.Cpf == autor.Cpf && f.Id != autor.Id).Result.Any())
            {
                Notificar("Já existe um fornecedor com este documento infomado.");
                return false;
            }

            await _autorRepository.Atualizar(autor);
            return true;
        }

        public void Dispose()
        {
            _autorRepository?.Dispose();
        }

        public async Task<bool> Remover(Guid id)
        {
            if (_autorRepository.ObterAutorPorLivro(id).Result.Nome.Any())
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
