using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class LabelMap : IEntityTypeConfiguration<Label>
    {
        public void Configure(EntityTypeBuilder<Label> builder)
        {
            builder.ToTable("label");

            builder.HasKey(label => label.Id);
            builder.Property(label => label.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder.Property(label => label.Regiao)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(30);

            builder.Property(label => label.Descricao)
                .IsRequired(false)
                .HasColumnType("VARCHAR")
                .HasMaxLength(300);

            builder.HasMany(label => label.Discos)
                .WithOne(disco => disco.Label)
                .HasForeignKey(disco => disco.IdLabel); 
        }
    }
}
