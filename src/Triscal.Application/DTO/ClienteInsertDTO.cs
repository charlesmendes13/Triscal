using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Triscal.Application.Helpers;

namespace Triscal.Application.DTO
{
    public class ClienteInsertDTO
    {
        [Required(ErrorMessage = "O Nome não pode ser nulo")]
        [MaxLength(30, ErrorMessage = "O Nome não pode ter mais que 30 caracteres")]
        [RegularExpression(@"^[ a-zA-ZÀ-ú]*$", ErrorMessage = "Digite um Nome válido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento não pode ser nula")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^[[0-9]{2}[-|\/]{1}[0-9]{2}[-|\/]{1}[0-9]{4}]*$", ErrorMessage = "Digite uma Data Nascimento válida")]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "O CPF não pode ser nulo")]
        [MinLength(11, ErrorMessage = "O CPF não pode ter menos que 11 caracteres")]
        [MaxLength(14, ErrorMessage = "O CPF não pode ter mais que 14 caracteres")]
        [RegularExpression(@"^[0-9 .-]*$", ErrorMessage = "Digite um CPF válido")]
        [ValidationCPF(ErrorMessage = "O CPF é inválido")]
        public string Cpf { get; set; }

        public EnderecoInsertDTO Endereco { get; set; }
    }
}
