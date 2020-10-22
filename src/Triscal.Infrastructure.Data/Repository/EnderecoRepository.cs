using System;
using System.Collections.Generic;
using System.Text;
using Triscal.Domain.Entities;
using Triscal.Domain.Interfaces.Repository;
using Triscal.Infrastructure.Data.Context;
using Triscal.Infrastructure.Data.Factory;

namespace Triscal.Infrastructure.Data.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        private readonly TriscalFactory _factory;
        private readonly TriscalContext _context;

        public EnderecoRepository(TriscalFactory factory,
            TriscalContext context)
            : base(factory, context)
        {
            _factory = factory;
            _context = context;
        }
    }
}
