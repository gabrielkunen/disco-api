using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class CantorMap : IEntityTypeConfiguration<Cantor>
    {
        public void Configure(EntityTypeBuilder<Cantor> builder)
        {
            builder.ToTable("cantor");

            builder.HasKey(cantor => cantor.Id);

            builder.Property(cantor => cantor.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);

            builder.HasMany(cantor => cantor.Musicas)
                .WithMany(musica => musica.Cantores)
                .UsingEntity("cantormusica");
        }
    }
}
