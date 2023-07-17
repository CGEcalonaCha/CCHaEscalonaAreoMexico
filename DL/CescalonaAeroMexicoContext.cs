using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class CescalonaAeroMexicoContext : DbContext
{
    public CescalonaAeroMexicoContext()
    {
    }

    public CescalonaAeroMexicoContext(DbContextOptions<CescalonaAeroMexicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioVuelo> UsuarioVuelos { get; set; }

    public virtual DbSet<Vuelo> Vuelos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= CEscalonaAeroMexico; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF971E2A4A10");

            entity.ToTable("Usuario");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Contrasena)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UsuarioVuelo>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioVuelos).HasName("PK__UsuarioV__BDB0D95596E87822");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioVuelos)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__UsuarioVu__IdUsu__1BFD2C07");

            entity.HasOne(d => d.IdVuelosNavigation).WithMany(p => p.UsuarioVuelos)
                .HasForeignKey(d => d.IdVuelos)
                .HasConstraintName("FK__UsuarioVu__IdVue__1CF15040");
        });

        modelBuilder.Entity<Vuelo>(entity =>
        {
            entity.HasKey(e => e.IdVuelos).HasName("PK__Vuelos__C6AFB43A407EB1EF");

            entity.Property(e => e.Destino).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.FechaSalida)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NumeroVuelo)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Origen).HasColumnType("decimal(18, 0)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
