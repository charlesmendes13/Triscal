using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Triscal.Domain.Entities
{
    public class Cliente : Base
    {
        public virtual string Nome { get; set; }

        public virtual DateTime DataNascimento { get; set; }

        public virtual string Cpf { get; set; }

        public virtual Endereco Endereco { get; set; }
    }
}
