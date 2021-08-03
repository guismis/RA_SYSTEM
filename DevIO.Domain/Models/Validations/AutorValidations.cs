using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Domain.Models.Validations
{
    public class AutorValidations : AbstractValidator<Autor>
    {
        public AutorValidations()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Celular)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Cpf).IsValidCPF();
                
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("A campo {PropertyName} precisa ser fornecida")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}
