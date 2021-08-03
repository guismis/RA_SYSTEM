using DevIO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Domain.Interfaces
{
    public interface IAutorService : IDisposable
    {
        Task<bool> Adiciona(Autor autor);
        Task<bool> Atualizar(Autor autor);
        Task<bool> Remover(Guid id);

    }
}
