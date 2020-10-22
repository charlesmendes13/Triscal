using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Triscal.Domain.Entities;
using Triscal.Infrastructure.Data.Mapping;

namespace Triscal.Infrastructure.Data.Context
{
    public class TriscalContext : DbContext, IDisposable
    {
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }

        public TriscalContext(DbContextOptions<TriscalContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cliente>(new ClienteMap().Configure);
            builder.Entity<Endereco>(new EnderecoMap().Configure);            
        }
    }
}
