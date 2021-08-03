using DevIO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Domain.Data.Mapping
{
    public class AutorMapping : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Celular)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(250)");

            builder.ToTable("Autor");
        }
    }
}
