using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EX3.Models
{
    public partial class ex3Context : DbContext
    {

        public ex3Context(DbContextOptions<ex3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cajeros> Cajeros { get; set; }
        public virtual DbSet<MaquinasRegistradas> MaquinasRegistradas { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<Venta> Venta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cajeros>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("pk_cajeros");

                entity.Property(e => e.NomApels).HasMaxLength(255);
            });

            modelBuilder.Entity<MaquinasRegistradas>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("pk_maquinas");

                entity.ToTable("maquinas_registradas");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("pk_productos");

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4C803B3EB3");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Venta>(entity =>
            {
                entity.HasKey(e => new { e.Cajero, e.Maquina, e.Producto })
                    .HasName("pk_venta");

                entity.HasOne(d => d.CajeroNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Cajero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venta1");

                entity.HasOne(d => d.MaquinaNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Maquina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venta2");

                entity.HasOne(d => d.ProductoNavigation)
                    .WithMany(p => p.Venta)
                    .HasForeignKey(d => d.Producto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_venta3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
