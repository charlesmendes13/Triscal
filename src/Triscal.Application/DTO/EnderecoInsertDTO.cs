using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Triscal.Application.DTO
{
    public class EnderecoInsertDTO
    {
        [Required(ErrorMessage = "O Logradouro não pode ser nulo")]
        [MaxLength(50, ErrorMessage = "O Logradouro não pode ter mais que 50 caracteres")]
        [RegularExpression(@"^[ a-zA-ZÀ-ú0-9 ,-]*$", ErrorMessage = "Digite um Logradouro válido")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Bairro não pode ser nulo")]
        [MaxLength(30, ErrorMessage = "O Bairro não pode ter mais que 30 caracteres")]
        [RegularExpression(@"^[ a-zA-ZÀ-ú0-9]*$", ErrorMessage = "Digite um Bairro válido")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A Cidade não pode ser nula")]
        [MaxLength(30, ErrorMessage = "O Cidade não pode ter mais que 30 caracteres")]
        [RegularExpression(@"^[ a-zA-ZÀ-ú0-9]*$", ErrorMessage = "Digite uma Cidade válida")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado não pode ser nulo")]
        [MaxLength(30, ErrorMessage = "O Estado não pode ter mais que 30 caracteres")]
        [RegularExpression(@"^[ a-zA-ZÀ-ú0-9]*$", ErrorMessage = "Digite um Estado válido")]
        public string Estado { get; set; }

        public Guid ClienteId { get; set; }
    }    
}
