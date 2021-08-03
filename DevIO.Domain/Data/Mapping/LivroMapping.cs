using DevIO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Domain.Data.Mapping
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.NomeDoLivro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.DataLancamento)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Edicao)
                .IsRequired()
                .HasColumnType("varchar(8)");

            
            builder.ToTable("Livro");
        }
    }
}
