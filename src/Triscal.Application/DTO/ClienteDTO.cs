using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Triscal.Application.DTO
{
    public class ClienteDTO
    {
        public Guid Id { get; set; }
        
        public string Nome { get; set; }
      
        public string DataNascimento { get; set; }
      
        public string Cpf { get; set; }

        public EnderecoDTO Endereco { get; set; }
    }
}
