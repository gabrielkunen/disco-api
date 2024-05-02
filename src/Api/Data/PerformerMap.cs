using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class PerformerMap : IEntityTypeConfiguration<Performer>
    {
        public void Configure(EntityTypeBuilder<Performer> builder)
        {
            builder.ToTable("performer");

            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(200);
        }
    }
}
