using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Triscal.Domain.Entities;
using Triscal.Domain.Extensions;

namespace Triscal.Domain.Validation
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().NotNull()
                .WithMessage("O Nome não pode ser nulo")
                .Length(1, 30)
                .WithMessage("O Nome não pode ter mais que 30 caracteres")
                .Matches(@"^[ a-zA-ZÀ-ú]*$")
                .WithMessage("O Nome deve possuir somente letras");

            RuleFor(x => x.DataNascimento)
                .NotNull().NotNull()
                .WithMessage("A Data de Nascimento não pode ser nula");

            RuleFor(x => x.Cpf)
                .NotEmpty().NotNull()
                .WithMessage("O CPF não pode ser nulo")
                .Length(11, 11)
                .WithMessage("O CPF deve ter 11 caracteres")
                .Matches(@"^[0-9]*$")
                .WithMessage("O CPF deve possuir somente números")
                .Must(ValidarExtension.ValidarCpf)
                .WithMessage("O CPF é inválido");

            RuleFor(x => x.Endereco)
               .SetValidator(new EnderecoValidation());
        }  
    }
}
