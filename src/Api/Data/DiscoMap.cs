using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class DiscoMap : IEntityTypeConfiguration<Disco>
    {
        public void Configure(EntityTypeBuilder<Disco> builder)
        {
            builder.ToTable("disco");

            builder.HasKey(disco => disco.Id);
            builder.Property(disco => disco.NumeroCatalogo)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);
            builder.Property(disco => disco.Titulo)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);
            builder.Property(disco => disco.DataLancamento)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder.Property(disco => disco.PrecoLancamento)
                .IsRequired()
                .HasColumnType("INT");

            builder.Property(disco => disco.TipoMedia)
                .IsRequired()
                .HasColumnType("INT");

            builder.HasOne(disco => disco.Label)
                .WithMany(label => label.Discos)
                .HasForeignKey(disco => disco.IdLabel);

            builder.HasMany(disco => disco.Musicas)
                .WithOne(musica => musica.Disco)
                .HasForeignKey(musica => musica.IdDisco);

            builder.HasOne(disco => disco.BarCode)
                .WithOne(barcode => barcode.Disco)
                .HasForeignKey<BarCode>(barcode => barcode.IdDisco);
        }
    }
}
