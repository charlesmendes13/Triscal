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

        public override async Task<Cliente> InsertAsync(Cliente entity)
        {
            var cliente = await _clienteRepository.GetCpfInsertAsync(entity);

            if (cliente != null)
            {
                return null;
            }

            return await _clienteRepository.InsertAsync(entity);
        }

        public override async Task<Cliente> UpdateAsync(Cliente entity)
        {
            var cliente = await _clienteRepository.GetCpfUpdateAsync(entity);

            if (cliente != null)
            {
                return null;
            }

            return await _clienteRepository.UpdateAsync(entity);
        }
    }
}
