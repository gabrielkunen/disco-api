using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data
{
    public class BarCodeMap : IEntityTypeConfiguration<BarCode>
    {
        public void Configure(EntityTypeBuilder<BarCode> builder)
        {
            builder.ToTable("barcode");

            builder.HasKey(barcode => barcode.Id);

            builder.Property(barcode => barcode.Codigo)
                .IsRequired()
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.HasOne(barcode => barcode.Disco)
                .WithOne(disco => disco.BarCode)
                .HasForeignKey<BarCode>(barcode => barcode.IdDisco);
        }
    }
}
