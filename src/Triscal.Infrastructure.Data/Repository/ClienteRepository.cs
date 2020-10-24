using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Triscal.Domain.Entities;
using Triscal.Domain.Interfaces.Repository;
using Triscal.Infrastructure.Data.Context;

namespace Triscal.Infrastructure.Data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        private readonly TriscalContext _context;

        public ClienteRepository(TriscalContext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            try
            {
                return await _context.Cliente
                    .Select(c => new Cliente
                    {
                        Id = c.Id,
                        Nome = c.Nome,
                        DataNascimento = c.DataNascimento,
                        Cpf = c.Cpf, 
                        Endereco = c.Endereco                       
                    })
                    .ToListAsync();
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
                return await _context.Cliente
                    .Where(x => x.Id == Guid.Parse(id.ToString()))
                    .Select(c => new Cliente
                    {
                        Id = c.Id,
                        Nome = c.Nome,
                        DataNascimento = c.DataNascimento,
                        Cpf = c.Cpf,
                        Endereco = c.Endereco
                    })
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<Cliente> InsertAsync(Cliente entity)
        {
            try
            {
                var cpf = await _context.Cliente
                    .FirstOrDefaultAsync(x => x.Cpf == entity.Cpf);

                if (cpf != null)
                {
                    return null;
                }

                await _context.Set<Cliente>().AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<Cliente> UpdateAsync(Cliente entity)
        {
            try
            {
                var cpf = await _context.Cliente
                    .FirstOrDefaultAsync(x => x.Id != entity.Id && x.Cpf == entity.Cpf);

                if (cpf != null)
                {
                    return null;
                }

                _context.Update(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
