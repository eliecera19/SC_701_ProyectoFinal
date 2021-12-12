using FincaAPI.DO.Objects;
using Microsoft.EntityFrameworkCore;

namespace FincaAPI.EF
{
    public partial class FincaContext : DbContext
    {
        public FincaContext()
        {
        }

        public FincaContext(DbContextOptions<FincaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animales> Animales { get; set; }
        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<Colores> Colores { get; set; }
        public virtual DbSet<EntradaConceptos> EntradaConceptos { get; set; }
        public virtual DbSet<Generos> Generos { get; set; }
        public virtual DbSet<Numeros> Numeros { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SalidaConceptos> SalidaConceptos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animales>(entity =>
            {
                entity.HasKey(e => e.AnimalId);

                entity.Property(e => e.AnimalConsumoMonto).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AnimalEntradaFecha).HasColumnType("date");

                entity.Property(e => e.AnimalEntradaPeso).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AnimalEntradaPrecio).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AnimalGananciaMonto).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AnimalGananciaPorcentaje).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AnimalSalidaFecha).HasColumnType("datetime");

                entity.Property(e => e.AnimalSalidaPeso).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AnimalSalidaPrecio).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.AnimalColor)
                    .WithMany(p => p.Animales)
                    .HasForeignKey(d => d.AnimalColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animales_Colores");

                entity.HasOne(d => d.AnimalEntradaConcepto)
                    .WithMany(p => p.Animales)
                    .HasForeignKey(d => d.AnimalEntradaConceptoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animales_EntradaConceptos");

                entity.HasOne(d => d.AnimalGenero)
                    .WithMany(p => p.Animales)
                    .HasForeignKey(d => d.AnimalGeneroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animales_Generos");

                entity.HasOne(d => d.AnimalNumero)
                    .WithMany(p => p.Animales)
                    .HasForeignKey(d => d.AnimalNumeroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animales_Numeros");

                entity.HasOne(d => d.AnimalSalidaConcepto)
                    .WithMany(p => p.Animales)
                    .HasForeignKey(d => d.AnimalSalidaConceptoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animales_SalidaConceptos");
            });

            modelBuilder.Entity<Bitacora>(entity =>
            {
                entity.Property(e => e.ActionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Controller)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Bitacora)
                    .HasForeignKey(d => d.UsuarioId)
                    .HasConstraintName("FK_Bitacora_Usuarios");
            });

            modelBuilder.Entity<Colores>(entity =>
            {
                entity.HasKey(e => e.ColorId);

                entity.Property(e => e.ColorNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EntradaConceptos>(entity =>
            {
                entity.HasKey(e => e.EntradaConceptoId);

                entity.Property(e => e.EntradaConceptoNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Generos>(entity =>
            {
                entity.HasKey(e => e.GeneroId);

                entity.Property(e => e.GeneroNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Numeros>(entity =>
            {
                entity.HasKey(e => e.NumeroId);

                entity.Property(e => e.NumeroEstado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RolId);

                entity.Property(e => e.RolNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SalidaConceptos>(entity =>
            {
                entity.HasKey(e => e.SalidaConceptoId);

                entity.Property(e => e.SalidaConceptoNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.Property(e => e.UsuarioId);

                entity.Property(e => e.UsuarioApMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioApPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
