using DevIO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Domain.Interfaces
{
    public interface IEditoraService : IDisposable
    {
        Task<bool> Adicionar(Editora editora);
        Task<bool> Atualizar(Editora editora);
        Task<bool> Remover(Guid id);

       
    }
}
