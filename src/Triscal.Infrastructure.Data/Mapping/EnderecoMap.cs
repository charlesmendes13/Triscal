using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Triscal.Domain.Entities;

namespace Triscal.Infrastructure.Data.Mapping
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.HasKey(c => c.Id);
            builder.Property(p => p.Logradouro).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Bairro).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Cidade).HasMaxLength(30).IsRequired();
            builder.Property(p => p.Estado).HasMaxLength(30).IsRequired();
        }
    }
}
