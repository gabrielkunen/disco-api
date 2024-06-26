﻿using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Api.Data
{
    public class DiscoContext : DbContext
    {
        public DiscoContext(DbContextOptions<DiscoContext> options) : base(options)
        {

        }

        public DbSet<Disco> Discos { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Cantor> Cantores { get; set; }
        public DbSet<BarCode> BarCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DiscoMap());
            modelBuilder.ApplyConfiguration(new LabelMap());
            modelBuilder.ApplyConfiguration(new MusicaMap());
            modelBuilder.ApplyConfiguration(new CantorMap());
            modelBuilder.ApplyConfiguration(new BarCodeMap());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Conventions.Remove(typeof(CascadeDeleteConvention));
            configurationBuilder.Conventions.Remove(typeof(SqlServerOnDeleteConvention));
        }
    }
}
