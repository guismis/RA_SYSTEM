using DevIO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Domain.Interfaces
{
    public interface IAutorRepository : IRepository<Autor>
    {
       
        Task<Autor> ObterAutorPorLivro(Guid id);

        Task<IEnumerable<Autor>> ObterAutorLivros();
    }
}
