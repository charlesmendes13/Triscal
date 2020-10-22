using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triscal.Domain.Entities;
using Triscal.Domain.Interfaces.Repository;
using Triscal.Infrastructure.Data.Context;
using Triscal.Infrastructure.Data.Factory;

namespace Triscal.Infrastructure.Data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly TriscalFactory _factory;
        private readonly TriscalContext _context;

        public ClienteRepository(TriscalFactory factory,
            TriscalContext context)
            : base(factory, context)
        {
            _factory = factory;
            _context = context;
        }

        public override async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            try
            {
                var result = await _factory.DbConnection()
                    .QueryAsync<Cliente, Endereco, Cliente>($"" +
                    $"Select * From Cliente " +
                    $"Left Join Endereco On Cliente.Id = Endereco.ClienteId " +
                    $"", map: (cliente, endereco) =>
                    {                       
                        if (endereco != null)
                            cliente.Endereco = endereco;

                        return cliente;
                    });

                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<Cliente> GetByIdAsync(object id)
        {
            try
            {
                var result = await _factory.DbConnection()
                    .QueryAsync<Cliente, Endereco, Cliente>($"" +
                    $"Select * From Cliente " +
                    $"Left Join Endereco On Cliente.Id = Endereco.ClienteId " +
                    $"Where Cliente.Id = '{ id }'" +
                    $"", map: (cliente, endereco) =>
                    {
                        if (endereco != null)
                            cliente.Endereco = endereco;

                        return cliente;
                    });

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> GetCpfInsertAsync(Cliente cliente)
        {
            try
            {
                var result = await _factory.DbConnection()
                    .QueryAsync<Cliente>($"" +
                    $"Select * From Cliente " +                   
                    $"Where Cpf = '{ cliente.Cpf }'");            

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Cliente> GetCpfUpdateAsync(Cliente cliente)
        {
            try
            {
                var result = await _factory.DbConnection()
                    .QueryAsync<Cliente>($"" +
                    $"Select * From Cliente " +
                    $"Where Id != '{ cliente.Id }' " +
                    $"And Cpf = '{ cliente.Cpf }'");

                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
