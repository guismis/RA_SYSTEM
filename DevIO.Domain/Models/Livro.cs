using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Domain.Models
{
    public class Livro : Entity
    {
        //Nome do Livro, Edição, Data de Lançamento, Editora e Autor.
        public String NomeDoLivro { get; set; }
        public String Edicao { get; set; }
        public DateTime DataLancamento { get; set; }
        public Editora Editora { get; set; }
        public Autor Autor { get; set; }
        public int EditoraId { get; set; }
        public int AutorId { get; set; }
    }
}
