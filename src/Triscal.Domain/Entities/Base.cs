using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Triscal.Domain.Entities
{
    public class Base
    {
        [Key]
        public virtual Guid Id { get; set; }
    }
}
