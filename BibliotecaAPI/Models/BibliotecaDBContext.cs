using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BibliotecaAPI.Models
{
    public partial class BibliotecaDBContext : DbContext
    {
        public BibliotecaDBContext()
        {
        }

        public BibliotecaDBContext(DbContextOptions<BibliotecaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autore> Autores { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=BibliotecaDB; user=sa; password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Autore>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PK__autores__5FC3872D9819B25D");

                entity.ToTable("autores");

                entity.Property(e => e.IdAutor).HasColumnName("id_autor");

                entity.Property(e => e.ApeAutor)
                    .IsRequired()
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("ape_autor");

                entity.Property(e => e.NomAutor)
                    .IsRequired()
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("nom_autor");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PK__libros__EC09C24EF7E58E6F");

                entity.ToTable("libros");

                entity.Property(e => e.IdLibro).HasColumnName("id_libro");

                entity.Property(e => e.CantidadPaginas).HasColumnName("cantidad_paginas");

                entity.Property(e => e.IdAutor).HasColumnName("id_autor");

                entity.Property(e => e.NomLibro)
                    .IsRequired()
                    .HasMaxLength(240)
                    .IsUnicode(false)
                    .HasColumnName("nom_libro");

                entity.Property(e => e.FechaPublicacion).HasColumnType("date").HasColumnName("fecha_publicacion");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdAutor)
                    .HasConstraintName("fk_autores");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
