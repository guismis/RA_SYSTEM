using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Domain.Models.Validations
{
    public class EditoraValidations : AbstractValidator<Editora>
    {
        public EditoraValidations()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Endereco)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Cnpj).IsValidCNPJ();



        }
    }
}
