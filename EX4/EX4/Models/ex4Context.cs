using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EX4.Models
{
    public partial class ex4Context : DbContext
    {
        public ex4Context(DbContextOptions<ex4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipos> Equipos { get; set; }
        public virtual DbSet<Facultad> Facultad { get; set; }
        public virtual DbSet<Investigadores> Investigadores { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipos>(entity =>
            {
                entity.HasKey(e => e.NumSerie)
                    .HasName("pk_equipo");

                entity.Property(e => e.NumSerie)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.HasOne(d => d.FacultadNavigation)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.Facultad)
                    .HasConstraintName("fk_equipo");
            });

            modelBuilder.Entity<Facultad>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("pk_facultad");

                entity.Property(e => e.Codigo).ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Investigadores>(entity =>
            {
                entity.HasKey(e => e.Dni)
                    .HasName("pk_investigadores");

                entity.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NomApels).HasMaxLength(255);

                entity.HasOne(d => d.FacultadNavigation)
                    .WithMany(p => p.Investigadores)
                    .HasForeignKey(d => d.Facultad)
                    .HasConstraintName("fk_investigadores");
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => new { e.Dni, e.NumSerie })
                    .HasName("pk_reserva");

                entity.Property(e => e.Dni)
                    .HasColumnName("DNI")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.NumSerie)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Comienzo).HasColumnType("datetime");

                entity.Property(e => e.Fin).HasColumnType("datetime");

                entity.HasOne(d => d.DniNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.Dni)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reserva1");

                entity.HasOne(d => d.NumSerieNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.NumSerie)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_reserva2");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4C5B859133");

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
