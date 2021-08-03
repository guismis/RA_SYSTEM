using DevIO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Domain.Interfaces
{
    public interface IEditoraRepository : IRepository<Editora>
    {
       
        Task<Editora> ObterAutorPorEditora(Guid id);
        Task<IEnumerable<Editora>> ObterEditorasLivros();
    }
}
