using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Hims.Arquitecture.Models;

public partial class HimsContext : DbContext
{
    public HimsContext()
    {
    }

    public HimsContext(DbContextOptions<HimsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }
    public virtual DbSet<Servicio> Servicios { get; set; }
    public virtual DbSet<Cita> Citas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ASUSLAW\\MSSQLSERVER02;Database=HIMS;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK__Clientes__71ABD08763346BAE");

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.App).HasMaxLength(100);
            entity.Property(e => e.CifNif)
                .HasMaxLength(50)
                .HasColumnName("CIF_NIF");
            entity.Property(e => e.CodigoPostal).HasMaxLength(10);
            entity.Property(e => e.Cumpleaños).HasMaxLength(10);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Dni)
                .HasMaxLength(50)
                .HasColumnName("DNI");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Genero).HasMaxLength(20);
            entity.Property(e => e.Grupos).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio);

            entity.Property(e => e.NombreDelServicio)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.DuracionServicio).IsRequired();

            entity.Property(e => e.PrecioServicio)
                .IsRequired()
                .HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.CitaId);

            entity.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.Telefono).HasMaxLength(20);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Estado).HasMaxLength(50).HasDefaultValue("Activa");
            entity.Property(e => e.Comentarios).HasMaxLength(255);

            entity.HasOne<Servicio>()
                .WithMany()
                .HasForeignKey(e => e.IdServicio)
                .OnDelete(DeleteBehavior.Cascade);

            entity.Property(e => e.FechaCita).IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
