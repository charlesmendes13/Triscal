using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Triscal.Domain.Entities;

namespace Triscal.Domain.Validation
{
    public class EnderecoValidation : AbstractValidator<Endereco>
    {
        public EnderecoValidation()
        {
            RuleFor(x => x.Logradouro)
                .NotEmpty().NotNull()
                .WithMessage("O Logradouro não pode ser nulo")
                .Length(1, 50)
                .WithMessage("O Logradouro não pode ter mais que 50 caracteres")
                .Matches(@"^[ a-zA-ZÀ-ú0-9 ,-]*$")
                .WithMessage("O Logradouro somente pode possuir letras, números, ',' e '-'");

            RuleFor(x => x.Bairro)
                .NotEmpty().NotNull()
                .WithMessage("O Bairro não pode ser nulo")
                .Length(1, 30)
                .WithMessage("O Bairro não pode ter mais que 30 caracteres")
                .Matches(@"^[ a-zA-ZÀ-ú0-9]*$")
                .WithMessage("O Bairro somente pode possuir letras e números");

            RuleFor(x => x.Cidade)
                .NotEmpty().NotNull()
                .WithMessage("A Cidade não pode ser nulo")
                .Length(1, 30)
                .WithMessage("A Cidade não pode ter mais que 30 caracteres")
                .Matches(@"^[ a-zA-ZÀ-ú0-9]*$")
                .WithMessage("A Cidade somente pode possuir letras e números");

            RuleFor(x => x.Estado)
                .NotEmpty().NotNull()
                .WithMessage("O Estado não pode ser nulo")
                .Length(1, 30)
                .WithMessage("O Estado não pode ter mais que 30 caracteres")
                .Matches(@"^[ a-zA-ZÀ-ú0-9]*$")
                .WithMessage("O Estado somente pode possuir letras e números");            
        }
    }
}
