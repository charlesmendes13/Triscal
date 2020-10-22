using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Triscal.Domain.Entities
{
    public class Cliente : Base
    {
        [Required]
        public virtual string Nome { get; set; }

        [Required]
        public virtual DateTime DataNascimento { get; set; }

        [Required]
        public virtual string Cpf { get; set; }

        public virtual Endereco Endereco { get; set; }
    }
}
