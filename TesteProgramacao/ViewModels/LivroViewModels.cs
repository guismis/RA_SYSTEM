using System;
using System.Collections.Generic;
using System.Text;

namespace TesteProgramacao.ViewModels
{
    public class LivroViewModels : EntityViewModels
    {
        //Nome do Livro, Edição, Data de Lançamento, Editora e Autor.
        public String NomeDoLivro { get; set; }
        public String Edicao { get; set; }
        public DateTime DataLancamento { get; set; }
        public EditoraViewModels Editora { get; set; }
        public AutorViewModels Autor { get; set; }
        public int EditoraId { get; set; }
        public int AutorId { get; set; }
    }
}
