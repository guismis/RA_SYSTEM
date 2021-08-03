using DevIO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Domain.Interfaces
{
    public interface ILivroService
    {
        Task<bool> Adicionar(Livro livro);
        Task<bool> Atualizar(Livro livro);
        Task<bool> Remover(Guid id);

    }
}
