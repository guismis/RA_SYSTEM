using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Domain.Models
{
    public class Autor : Entity
    {
        //Nome, CPF(com validação se é valido ou não), celular, e-mail.
        public String Nome { get; set; }
        public String Cpf { get; set; }
        public String Celular { get; set; }
        public String Email { get; set; }

        public IList<Livro> Livros { get; set; }

    }
}
