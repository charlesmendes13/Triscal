using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Triscal.Domain.Entities;
using Triscal.Domain.Interfaces.Repository;
using Triscal.Domain.Interfaces.Services;

namespace Triscal.Domain.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
    }
}
