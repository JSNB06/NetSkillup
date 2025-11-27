using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Proyecto.Models;

public partial class NetskillupContext : DbContext
{
    public NetskillupContext()
    {
    }

    public NetskillupContext(DbContextOptions<NetskillupContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Evaluacione> Evaluaciones { get; set; }

    public virtual DbSet<Inscripcione> Inscripciones { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolesSistema> RolesSistemas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCursos).HasName("PRIMARY");

            entity
                .ToTable("cursos")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.NombreCurso, "uniq_nombre_curso").IsUnique();

            entity.Property(e => e.IdCursos)
                .HasColumnType("int(11)")
                .HasColumnName("ID_CURSOS");
            entity.Property(e => e.NombreCurso)
                .HasMaxLength(150)
                .HasColumnName("NOMBRE_CURSO");
        });

        modelBuilder.Entity<Evaluacione>(entity =>
        {
            entity.HasKey(e => e.IdEvaluacion).HasName("PRIMARY");

            entity.ToTable("evaluaciones");

            entity.HasIndex(e => e.IdModulo, "fk_eval_modulo");

            entity.Property(e => e.IdEvaluacion)
                .HasColumnType("int(11)")
                .HasColumnName("ID_EVALUACION");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.IdModulo)
                .HasColumnType("int(11)")
                .HasColumnName("ID_MODULO");
            entity.Property(e => e.Titulo)
                .HasMaxLength(150)
                .HasColumnName("TITULO");

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.Evaluaciones)
                .HasForeignKey(d => d.IdModulo)
                .HasConstraintName("fk_eval_modulo");
        });

        modelBuilder.Entity<Inscripcione>(entity =>
        {
            entity.HasKey(e => e.IdInscripcion).HasName("PRIMARY");

            entity.ToTable("inscripciones");

            entity.HasIndex(e => e.Identificacion, "fk_inscripcion_usuario");

            entity.HasIndex(e => new { e.IdCursos, e.Identificacion }, "uniq_inscripcion").IsUnique();

            entity.Property(e => e.IdInscripcion)
                .HasColumnType("int(11)")
                .HasColumnName("ID_INSCRIPCION");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'inscrito'")
                .HasColumnType("enum('inscrito','en_progreso','finalizado','cancelado')")
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaInscripcion)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INSCRIPCION");
            entity.Property(e => e.IdCursos)
                .HasColumnType("int(11)")
                .HasColumnName("ID_CURSOS");
            entity.Property(e => e.Identificacion)
                .HasColumnType("int(11)")
                .HasColumnName("IDENTIFICACION");

            entity.HasOne(d => d.IdCursosNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.IdCursos)
                .HasConstraintName("fk_inscripcion_curso");

            entity.HasOne(d => d.IdentificacionNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.Identificacion)
                .HasConstraintName("fk_inscripcion_usuario");
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.IdModulo).HasName("PRIMARY");

            entity.ToTable("modulos");

            entity.HasIndex(e => e.IdCursos, "fk_modulo_curso");

            entity.Property(e => e.IdModulo)
                .HasColumnType("int(11)")
                .HasColumnName("ID_MODULO");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.IdCursos)
                .HasColumnType("int(11)")
                .HasColumnName("ID_CURSOS");
            entity.Property(e => e.NombreModulo)
                .HasMaxLength(150)
                .HasColumnName("NOMBRE_MODULO");
            entity.Property(e => e.Orden)
                .HasDefaultValueSql("'1'")
                .HasColumnType("int(11)")
                .HasColumnName("ORDEN");

            entity.HasOne(d => d.IdCursosNavigation).WithMany(p => p.Modulos)
                .HasForeignKey(d => d.IdCursos)
                .HasConstraintName("fk_modulo_curso");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PRIMARY");

            entity
                .ToTable("rol")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("idRol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<RolesSistema>(entity =>
        {
            entity.HasKey(e => e.Identificacion).HasName("PRIMARY");

            entity
                .ToTable("roles_sistema")
                .HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.Correo, "ID_CORREO").IsUnique();

            entity.HasIndex(e => e.IdRol, "fk_rs_rol");

            entity.Property(e => e.Identificacion)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("IDENTIFICACION");
            entity.Property(e => e.Apellido1)
                .HasMaxLength(255)
                .HasColumnName("apellido1");
            entity.Property(e => e.Apellido2)
                .HasMaxLength(255)
                .HasColumnName("apellido2");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .HasColumnName("contraseña");
            entity.Property(e => e.Correo).HasColumnName("correo");
            entity.Property(e => e.IdRol)
                .HasColumnType("int(11)")
                .HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolesSistemas)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("fk_rs_rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
