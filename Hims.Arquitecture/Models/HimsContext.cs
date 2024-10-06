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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-PCB1OR7;Database=HIMS;Trusted_Connection=True;TrustServerCertificate=True;");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
