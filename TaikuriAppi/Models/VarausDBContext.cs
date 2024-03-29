﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaikuriAppi.Models
{
    public partial class VarausDBContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<VarausDBContext> _logger;
        public VarausDBContext(IConfiguration configuration, ILogger<VarausDBContext> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
        public VarausDBContext()
        {
           
        }

        public VarausDBContext(DbContextOptions<VarausDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asiaka> Asiakas { get; set; } = null!;
        public virtual DbSet<Taikuri> Taikuris { get; set; } = null!;
        public virtual DbSet<Varaukset> Varauksets { get; set; } = null!;

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asiaka>(entity =>
            {
                entity.HasKey(e => e.AsiakasId)
                    .HasName("PK__Asiakas__9FC315590B0E2F9A");

                entity.Property(e => e.AsiakasId).HasColumnName("asiakasID");

                entity.Property(e => e.Etunimi)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Osoite)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sukunimi)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Taikuri>(entity =>
            {
                entity.ToTable("Taikuri");

                entity.Property(e => e.TaikuriId).HasColumnName("taikuriID");

                entity.Property(e => e.Lokaatio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Taidot)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Taiteilijanimi)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Toimialat)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Varaukset>(entity =>
            {
                entity.HasKey(e => e.VarausId)
                    .HasName("PK__Varaukse__1301A7C43E7E9F15");

                entity.ToTable("Varaukset");

                entity.Property(e => e.VarausId).HasColumnName("varausID");

                entity.Property(e => e.AsiakasId).HasColumnName("asiakasID");

                entity.Property(e => e.Päivämäärä)
                    .HasColumnType("date")
                    .HasColumnName("päivämäärä");

                entity.Property(e => e.TaikuriId).HasColumnName("taikuriID");

                entity.HasOne(d => d.Asiakas)
                    .WithMany(p => p.Varauksets)
                    .HasForeignKey(d => d.AsiakasId)
                    .HasConstraintName("FK__Varaukset__asiak__286302EC");

                entity.HasOne(d => d.Taikuri)
                    .WithMany(p => p.Varauksets)
                    .HasForeignKey(d => d.TaikuriId)
                    .HasConstraintName("FK__Varaukset__taiku__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
