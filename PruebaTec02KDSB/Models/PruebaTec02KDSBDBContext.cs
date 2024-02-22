using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PruebaTec02KDSB.Models
{
    public partial class PruebaTec02KDSBDBContext : DbContext
    {
        public PruebaTec02KDSBDBContext()
        {
        }

        public PruebaTec02KDSBDBContext(DbContextOptions<PruebaTec02KDSBDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ceramica> Ceramicas { get; set; } = null!;
        public virtual DbSet<Medida> Medidas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-U3NM1TE; database=PruebaTec02KDSBDB; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ceramica>(entity =>
            {
                entity.ToTable("ceramica");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("precio");

                entity.Property(e => e.TamañoId).HasColumnName("tamaño_id");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.Tamaño)
                    .WithMany(p => p.Ceramicas)
                    .HasForeignKey(d => d.TamañoId)
                    .HasConstraintName("FK__ceramica__tamaño__5070F446");
            });

            modelBuilder.Entity<Medida>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Medida1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("medida");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
