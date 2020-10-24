using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Triscal.Application.Helpers;

namespace Triscal.Application.DTO
{
    public class ClienteCreateDTO
    {
        [Required(ErrorMessage = "O Nome não pode ser nulo")]
        [MaxLength(30, ErrorMessage = "O Nome não pode ter mais que 30 caracteres")]
        [RegularExpression(@"^[ a-zA-ZÀ-ú]*$", ErrorMessage = "O Nome deve possuir somente letras")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento não pode ser nula")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^[[0-9]{2}[-|\/]{1}[0-9]{2}[-|\/]{1}[0-9]{4}]*$", ErrorMessage = "A Data Nascimento deve possuir números, '-' ou '/'")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "O CPF não pode ser nulo")]
        [MaxLength(11, ErrorMessage = "O CPF não pode ter mais que 11 caracteres")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "O CPF deve possuir somente números")]
        [ValidationCPF(ErrorMessage = "O CPF é inválido")]
        public string Cpf { get; set; }

        public ClienteEnderecoCreateDTO Endereco { get; set; }
    }
}
