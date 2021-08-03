using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Domain.Models.Validations
{
    public class LivroValidations : AbstractValidator<Livro>
    {
        public LivroValidations()
        {
            RuleFor(c => c.NomeDoLivro)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Edicao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(8).WithMessage("O campo {PropertyName} precisa ter {MaxLength} caracteres");

         
        }
    }
}
