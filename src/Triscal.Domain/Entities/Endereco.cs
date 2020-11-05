using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Triscal.Domain.Entities
{
    public class Endereco : Base
    {
        public virtual string Logradouro { get; set; }

        public virtual string Bairro { get; set; }

        public virtual string Cidade { get; set; }

        public virtual string Estado { get; set; }

        [ForeignKey("User")]
        public virtual Guid ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}
