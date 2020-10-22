using System;
using System.Collections.Generic;
using System.Text;
using Triscal.Application.Interfaces;
using Triscal.Domain.Entities;
using Triscal.Domain.Interfaces.Services;

namespace Triscal.Application.Services
{
    public class ClienteAppService : BaseAppService<Cliente>, IClienteAppService
    {
        public readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
            : base(clienteService)
        {
            _clienteService = clienteService;
        }
    }
}
