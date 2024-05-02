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

            builder.HasKey(x => x.Id);
            builder.Property(p => p.NumeroCatalogo)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);
            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);

            builder.HasOne(disco => disco.Label)
                .WithMany(label => label.Discos)
                .HasForeignKey(disco => disco.IdLabel);

            builder.HasMany(disco => disco.Performers)
                .WithMany(perf => perf.Discos)
                .UsingEntity("discoperformer");
        }
    }
}
