using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class MusicaMap : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder.ToTable("musica");

            builder.HasKey(musica => musica.Id);

            builder.Property(musica => musica.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.HasOne(musica => musica.Disco)
                .WithMany(disco => disco.Musicas)
                .HasForeignKey(musica => musica.IdDisco);

            builder.HasMany(musica => musica.Cantores)
                .WithMany(cantor => cantor.Musicas)
                .UsingEntity("cantormusica");
        }
    }
}
