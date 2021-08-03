using DevIO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Domain.Interfaces
{
    public interface ILivroRepository : IRepository<Livro>
    {
        Task<IEnumerable<Livro>> ObterEditoraPorLivro(Guid livroId);
        Task<IEnumerable<Livro>> ObterAutorPorLivro(Guid livroId);
        Task<Livro> ObterEditorasAutorLivro(Guid id);

    }
}
