using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Triscal.Application.DTO
{
    public class EnderecoDTO
    {
        public Guid Id { get; set; }
       
        public string Logradouro { get; set; }
     
        public string Bairro { get; set; }

        public string Cidade { get; set; }
       
        public string Estado { get; set; }

        public Guid ClienteId { get; set; }
    }
}
