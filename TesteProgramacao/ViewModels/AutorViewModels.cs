using DevIO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteProgramacao.ViewModels
{
    public class AutorViewModels : EntityViewModels
    {
        //Nome, CPF(com validação se é valido ou não), celular, e-mail.
        public String Nome { get; set; }
        public String Cpf { get; set; }
        public String Celular { get; set; }
        public String Email { get; set; }

        public IList<LivroViewModels> Livros { get; set; }

    }
}
