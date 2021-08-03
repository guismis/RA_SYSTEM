using DevIO.Domain.Data.Context;
using DevIO.Domain.Interfaces;
using DevIO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Domain.Data.Repository
{
    public class EditoraRepository : Repository<Editora>, IEditoraRepository
    {
        public EditoraRepository(CatalogoDbContext context) : base(context) { }

        public async Task<Editora> ObterAutorPorEditora(Guid autorId)
        {
            return await Db.Editoras.AsNoTracking()
                           .FirstOrDefaultAsync(f => f.Id == autorId);
        }

        public async Task<IEnumerable<Editora>> ObterEditorasLivros()
        {
            return await Db.Editoras.AsNoTracking().Include(f => f.Livros)
                .OrderBy(p => p.Nome).ToListAsync();
        }
    }
}
