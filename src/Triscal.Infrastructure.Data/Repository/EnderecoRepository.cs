using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Triscal.Domain.Entities;
using Triscal.Domain.Interfaces.Repository;
using Triscal.Infrastructure.Data.Context;

namespace Triscal.Infrastructure.Data.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        private readonly TriscalContext _context;

        public EnderecoRepository(TriscalContext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<Endereco> InsertAsync(Endereco entity)
        {
            try
            {
                var clienteId = await _context.Endereco
                    .FirstOrDefaultAsync(x => x.ClienteId == entity.ClienteId);

                if (clienteId != null)
                {
                    return null;
                }

                await _context.Set<Endereco>().AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override async Task<Endereco> UpdateAsync(Endereco entity)
        {
            try
            {
                var clienteId = await _context.Endereco
                    .FirstOrDefaultAsync(x => x.Id != entity.Id && x.ClienteId == entity.ClienteId);

                if (clienteId != null)
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
