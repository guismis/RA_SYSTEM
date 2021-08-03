using DevIO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteProgramacao.ViewModels
{
    public class EditoraViewModels : EntityViewModels
    {
        //CPNJ(com validação se é valido ou não) Nome, endereço completo.
        public String Cnpj { get; set; }
        public String Nome { get; set; }
        public String Endereco { get; set; }

        public IList<LivroViewModels> Livros { get; set; }

    }
}
