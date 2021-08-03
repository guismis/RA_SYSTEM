using DevIO.Domain.Data.Context;
using DevIO.Domain.Interfaces;
using DevIO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Domain.Data.Repository
{
    public class LivroRepository : Repository<Livro>, ILivroRepository
    {
        public LivroRepository(CatalogoDbContext context) : base(context) { }

      

        public async Task<IEnumerable<Livro>> ObterAutorPorLivro(Guid livroId)
        {
            return (IEnumerable<Livro>)await Db.Livros.AsNoTracking()
                .Include(ps => ps.AutorId)
               .FirstOrDefaultAsync(f => f.Id == livroId);
        }

       

        public async Task<IEnumerable<Livro>> ObterEditoraPorLivro(Guid livroId)
        {
            return (IEnumerable<Livro>)await Db.Livros.AsNoTracking().Include(ps => ps.Editora)
                          .FirstOrDefaultAsync(f => f.Id == livroId);
        }

        public async Task<Livro> ObterEditorasAutorLivro(Guid id)
        {

            return await Db.Livros.AsNoTracking()
                .Include(c => c.Autor)
                .Include(c => c.Editora)
                .FirstOrDefaultAsync(c => c.Id == id);

        }

        
    }
}
