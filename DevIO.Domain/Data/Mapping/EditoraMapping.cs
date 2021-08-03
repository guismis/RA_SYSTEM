using DevIO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Domain.Data.Mapping
{
    class EditoraMapping : IEntityTypeConfiguration<Editora>
    {
        public void Configure(EntityTypeBuilder<Editora> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.Cnpj)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(c => c.Endereco)
                .IsRequired()
                .HasColumnType("varchar(8)");


            builder.ToTable("Editora");
        }
    }
}
