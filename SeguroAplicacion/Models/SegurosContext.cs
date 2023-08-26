using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SeguroAplicacion.Models;

public partial class SegurosContext : DbContext
{
    public SegurosContext()
    {
    }

    public SegurosContext(DbContextOptions<SegurosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Seguro> Seguros { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-213L5JE; Database=Seguros; Trusted_Connection=True; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Seguro>(entity =>
        {
            entity.HasKey(e => e.IdSeguro).HasName("PK__seguros__730AB2BACD926B66");

            entity.ToTable("seguros");

            entity.Property(e => e.CodigoSeguro)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.NombreSeguro)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Seguros)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK_seguros_IdUsuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuarios__3214EC0746BF8A8F");

            entity.ToTable("usuarios");

            entity.Property(e => e.Cedula)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Cliente)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Edad).HasColumnName("edad");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
