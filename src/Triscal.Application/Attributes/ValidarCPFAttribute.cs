using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Triscal.Domain.Extensions;

namespace Triscal.Application.Attributes
{
    internal class ValidarCPFAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {           
            return value.ToString().ValidarCpf();
        }        
    }
}
