using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Triscal.Application.DTO
{
    public class EnderecoCreateDTO
    {
        [Required(ErrorMessage = "O Logradouro não pode ser nulo")]
        [MaxLength(50, ErrorMessage = "O Logradouro não pode ter mais que 50 caracteres")]
        [RegularExpression(@"^[ a-zA-ZÀ-ú0-9 ,-]*$", ErrorMessage = "O Logradouro somente pode possuir letras, números, ',' e '-'")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Bairro não pode ser nulo")]
        [MaxLength(30, ErrorMessage = "O Bairro não pode ter mais que 30 caracteres")]
        [RegularExpression(@"^[ a-zA-ZÀ-ú0-9]*$", ErrorMessage = "O Bairro somente pode possuir letras, números, ',' e '-'")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A Cidade não pode ser nula")]
        [MaxLength(30, ErrorMessage = "O Cidade não pode ter mais que 30 caracteres")]
        [RegularExpression(@"^[ a-zA-ZÀ-ú0-9]*$", ErrorMessage = "A Cidade somente pode possuir letras, números, ',' e '-'")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado não pode ser nulo")]
        [MaxLength(30, ErrorMessage = "O Estado não pode ter mais que 30 caracteres")]
        [RegularExpression(@"^[ a-zA-ZÀ-ú0-9]*$", ErrorMessage = "O Estado somente pode possuir letras, números, ',' e '-'")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O ClienteId não pode ser nulo")]
        public Guid ClienteId { get; set; }
    }
}
