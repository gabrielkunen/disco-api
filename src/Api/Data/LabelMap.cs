﻿using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class LabelMap : IEntityTypeConfiguration<Label>
    {
        public void Configure(EntityTypeBuilder<Label> builder)
        {
            builder.ToTable("label");

            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder.Property(p => p.Regiao)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(30);

            builder.Property(p => p.Descricao)
                .IsRequired(false)
                .HasColumnType("VARCHAR")
                .HasMaxLength(300);

            builder.HasMany(label => label.Discos)
                .WithOne(disco => disco.Label)
                .HasForeignKey(disco => disco.IdLabel); 
        }
    }
}
