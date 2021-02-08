using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EX2.Models
{
    public partial class ex2Context : DbContext
    {

        public ex2Context(DbContextOptions<ex2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AsignadoA> AsignadoA { get; set; }
        public virtual DbSet<Cientificos> Cientificos { get; set; }
        public virtual DbSet<Proyecto> Proyecto { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsignadoA>(entity =>
            {
                entity.HasKey(e => new { e.Cientifico, e.Proyecto })
                    .HasName("pk_asignado");

                entity.ToTable("Asignado_a");

                entity.Property(e => e.Cientifico)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Proyecto)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.CientificoNavigation)
                    .WithMany(p => p.AsignadoA)
                    .HasForeignKey(d => d.Cientifico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_asignado1");

                entity.HasOne(d => d.ProyectoNavigation)
                    .WithMany(p => p.AsignadoA)
                    .HasForeignKey(d => d.Proyecto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_asignado2");
            });

            modelBuilder.Entity<Cientificos>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("pk_cientificos");

                entity.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NomApels)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Proyecto>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4CE131FC50");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
