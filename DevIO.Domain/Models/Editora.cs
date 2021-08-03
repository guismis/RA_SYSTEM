using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Domain.Models
{
    public class Editora : Entity
    {
        //CPNJ(com validação se é valido ou não) Nome, endereço completo.
        public String Cnpj { get; set; }
        public String Nome { get; set; }
        public String Endereco { get; set; }

        public IList<Livro> Livros { get; set; }

    }
}
