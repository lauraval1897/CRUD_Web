using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUD_Libreria.Models
{
    public partial class LibreriaContext : DbContext
    {
        public LibreriaContext()
        {
        }

        public LibreriaContext(DbContextOptions<LibreriaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Libreria> Libreria { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                //optionsBuilder.UseSqlServer("Server=DESKTOP-1DBUN64;Database=Libreria;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libreria>(entity =>
            {
                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AñoPublicacion).HasColumnName("Año_Publicacion");

                entity.Property(e => e.NombreLibro)
                    .IsRequired()
                    .HasColumnName("Nombre_Libro")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
