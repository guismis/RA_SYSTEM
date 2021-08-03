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
    public class AutorRepository : Repository<Autor>, IAutorRepository
    {
        public AutorRepository(CatalogoDbContext context) : base(context) { }

        public async Task<Autor> ObterAutorPorLivro( Guid autorId)
        {
            return await Db.Autors.AsNoTracking()
                           .FirstOrDefaultAsync(f => f.Id == autorId);
        }

        public async Task<IEnumerable<Autor>> ObterAutorLivros()
        {
            return await Db.Autors.AsNoTracking().Include(f => f.Livros)
                .OrderBy(p => p.Nome).ToListAsync();
        }
    }
}
