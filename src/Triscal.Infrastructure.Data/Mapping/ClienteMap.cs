using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Triscal.Domain.Entities;

namespace Triscal.Infrastructure.Data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.Id);
            builder.Property(p => p.Nome).HasMaxLength(30).IsRequired();
            builder.Property(p => p.DataNascimento).IsRequired();
            builder.HasIndex(p => p.Cpf).IsUnique();
        }
    }
}
