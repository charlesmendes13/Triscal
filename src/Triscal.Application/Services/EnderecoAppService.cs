using System;
using System.Collections.Generic;
using System.Text;
using Triscal.Application.Interfaces;
using Triscal.Domain.Entities;
using Triscal.Domain.Interfaces.Services;

namespace Triscal.Application.Services
{
    public class EnderecoAppService : BaseAppService<Endereco>, IEnderecoAppService
    {
        public readonly IEnderecoService _enderecoService;

        public EnderecoAppService(IEnderecoService enderecoService)
            : base(enderecoService)
        {
            _enderecoService = enderecoService;
        }
    }
}
