using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Server.Models;

public partial class AcademiaContext : DbContext
{
    public AcademiaContext()
    {
    }

    public AcademiaContext(DbContextOptions<AcademiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Academia> Academias { get; set; }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Colonia> Colonias { get; set; }

    public virtual DbSet<Cp> Cps { get; set; }

    public virtual DbSet<DatosAlumno> DatosAlumnos { get; set; }

    public virtual DbSet<Dia> Dias { get; set; }

    public virtual DbSet<Direccione> Direcciones { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<HorarioClases2> HorarioClases2s { get; set; }

    public virtual DbSet<Instructore> Instructores { get; set; }

    public virtual DbSet<LogAlumno> LogAlumnos { get; set; }

    public virtual DbSet<Matricula> Matriculas { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Padre> Padres { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Username> Usernames { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=academia;uid=root;password=n64ov7ov7", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Academia>(entity =>
        {
            entity.HasKey(e => e.Idacademias).HasName("PRIMARY");

            entity.ToTable("academias");

            entity.HasIndex(e => e.IdDirecciones, "idDirecciones_idx");

            entity.Property(e => e.Idacademias).HasColumnName("idacademias");
            entity.Property(e => e.IdDirecciones).HasColumnName("idDirecciones");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdDireccionesNavigation).WithMany(p => p.Academia)
                .HasForeignKey(d => d.IdDirecciones)
                .HasConstraintName("idDirecciones3");
        });

        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.Idalumnos).HasName("PRIMARY");

            entity.ToTable("alumnos");

            entity.HasIndex(e => e.User, "user_UNIQUE").IsUnique();

            entity.Property(e => e.Idalumnos).HasColumnName("idalumnos");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");
            entity.Property(e => e.Contacto)
                .HasMaxLength(45)
                .HasColumnName("contacto");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fechaNacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.TelefonoContacto)
                .HasMaxLength(45)
                .HasColumnName("telefonoContacto");
            entity.Property(e => e.User)
                .HasMaxLength(45)
                .HasColumnName("user");
        });

        modelBuilder.Entity<Colonia>(entity =>
        {
            entity.HasKey(e => e.Idcolonias).HasName("PRIMARY");

            entity.ToTable("colonias");

            entity.HasIndex(e => e.IdCps, "idCPs_idx");

            entity.Property(e => e.Idcolonias).HasColumnName("idcolonias");
            entity.Property(e => e.IdCps).HasColumnName("idCPs");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCpsNavigation).WithMany(p => p.Colonia)
                .HasForeignKey(d => d.IdCps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idCPs");
        });

        modelBuilder.Entity<Cp>(entity =>
        {
            entity.HasKey(e => e.IdCps).HasName("PRIMARY");

            entity.ToTable("cps");

            entity.HasIndex(e => e.IdMunicipios, "idMunicipios_idx");

            entity.Property(e => e.IdCps).HasColumnName("idCPs");
            entity.Property(e => e.Cp1)
                .HasMaxLength(10)
                .HasColumnName("CP");
            entity.Property(e => e.IdMunicipios).HasColumnName("idMunicipios");

            entity.HasOne(d => d.IdMunicipiosNavigation).WithMany(p => p.Cps)
                .HasForeignKey(d => d.IdMunicipios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idMunicipios");
        });

        modelBuilder.Entity<DatosAlumno>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("datos_alumnos");
        });

        modelBuilder.Entity<Dia>(entity =>
        {
            entity.HasKey(e => e.Iddias).HasName("PRIMARY");

            entity.ToTable("dias");

            entity.Property(e => e.Iddias).HasColumnName("iddias");
            entity.Property(e => e.Dias)
                .HasMaxLength(45)
                .HasColumnName("dias");
        });

        modelBuilder.Entity<Direccione>(entity =>
        {
            entity.HasKey(e => e.Iddirecciones).HasName("PRIMARY");

            entity.ToTable("direcciones");

            entity.HasIndex(e => e.IdColonias, "idColonias_idx");

            entity.Property(e => e.Iddirecciones).HasColumnName("iddirecciones");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .HasColumnName("calle");
            entity.Property(e => e.IdColonias).HasColumnName("idColonias");
            entity.Property(e => e.Numero)
                .HasMaxLength(50)
                .HasColumnName("numero");

            entity.HasOne(d => d.IdColoniasNavigation).WithMany(p => p.Direcciones)
                .HasForeignKey(d => d.IdColonias)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idColonias");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Idestados).HasName("PRIMARY");

            entity.ToTable("estados");

            entity.HasIndex(e => e.IdPaises, "idPaises_idx");

            entity.Property(e => e.Idestados).HasColumnName("idestados");
            entity.Property(e => e.Estado1)
                .HasMaxLength(45)
                .HasColumnName("estado");
            entity.Property(e => e.IdPaises).HasColumnName("idPaises");

            entity.HasOne(d => d.IdPaisesNavigation).WithMany(p => p.Estados)
                .HasForeignKey(d => d.IdPaises)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idPaises");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.Idgrupos).HasName("PRIMARY");

            entity.ToTable("grupos");

            entity.HasIndex(e => e.IdAcademias, "idAcademias_idx");

            entity.HasIndex(e => e.IdInstructores, "idInstructores_idx");

            entity.Property(e => e.Idgrupos).HasColumnName("idgrupos");
            entity.Property(e => e.IdAcademias).HasColumnName("idAcademias");
            entity.Property(e => e.IdInstructores).HasColumnName("idInstructores");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdAcademiasNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdAcademias)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idAcademias");

            entity.HasOne(d => d.IdInstructoresNavigation).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.IdInstructores)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idInstructores");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.Idhorarios).HasName("PRIMARY");

            entity.ToTable("horarios");

            entity.HasIndex(e => e.IdDias, "idDias_idx");

            entity.HasIndex(e => e.IdGrupos, "idGrupos2_idx");

            entity.Property(e => e.Idhorarios).HasColumnName("idhorarios");
            entity.Property(e => e.Hora)
                .HasColumnType("time")
                .HasColumnName("hora");
            entity.Property(e => e.IdDias).HasColumnName("idDias");
            entity.Property(e => e.IdGrupos).HasColumnName("idGrupos");
            entity.Property(e => e.Salon)
                .HasMaxLength(45)
                .HasColumnName("salon");

            entity.HasOne(d => d.IdDiasNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdDias)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idDias");

            entity.HasOne(d => d.IdGruposNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdGrupos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idGrupos2");
        });

        modelBuilder.Entity<HorarioClases2>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("horario_clases2");

            entity.Property(e => e.ApellidoDelInstructor).HasColumnName("Apellido del Instructor");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.NombreDelInstructor).HasColumnName("Nombre del Instructor");
        });

        modelBuilder.Entity<Instructore>(entity =>
        {
            entity.HasKey(e => e.Idinstructores).HasName("PRIMARY");

            entity.ToTable("instructores");

            entity.HasIndex(e => e.IdDirecciones, "idDirecciones4_idx");

            entity.Property(e => e.Idinstructores).HasColumnName("idinstructores");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(45)
                .HasColumnName("apellidos");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fechaNacimiento");
            entity.Property(e => e.IdDirecciones).HasColumnName("idDirecciones");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdDireccionesNavigation).WithMany(p => p.Instructores)
                .HasForeignKey(d => d.IdDirecciones)
                .HasConstraintName("idDirecciones4");
        });

        modelBuilder.Entity<LogAlumno>(entity =>
        {
            entity.HasKey(e => e.IdlogAlumnos).HasName("PRIMARY");

            entity.ToTable("log_alumnos");

            entity.Property(e => e.IdlogAlumnos).HasColumnName("idlog_alumnos");
            entity.Property(e => e.Accion)
                .HasMaxLength(200)
                .HasColumnName("accion");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
        });

        modelBuilder.Entity<Matricula>(entity =>
        {
            entity.HasKey(e => e.Idmatriculas).HasName("PRIMARY");

            entity.ToTable("matriculas");

            entity.HasIndex(e => e.IdAlumnos, "idAlumnos_idx");

            entity.HasIndex(e => e.IdGrupos, "idGrupos_idx");

            entity.Property(e => e.Idmatriculas).HasColumnName("idmatriculas");
            entity.Property(e => e.FechaIngreso).HasColumnName("fechaIngreso");
            entity.Property(e => e.IdAlumnos).HasColumnName("idAlumnos");
            entity.Property(e => e.IdGrupos).HasColumnName("idGrupos");

            entity.HasOne(d => d.IdAlumnosNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdAlumnos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idAlumnos2");

            entity.HasOne(d => d.IdGruposNavigation).WithMany(p => p.Matriculas)
                .HasForeignKey(d => d.IdGrupos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idGrupos");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.Idmunicipios).HasName("PRIMARY");

            entity.ToTable("municipios");

            entity.HasIndex(e => e.IdEstados, "idEstados_idx");

            entity.Property(e => e.Idmunicipios).HasColumnName("idmunicipios");
            entity.Property(e => e.IdEstados).HasColumnName("idEstados");
            entity.Property(e => e.Municipio1)
                .HasMaxLength(45)
                .HasColumnName("municipio");

            entity.HasOne(d => d.IdEstadosNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdEstados)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idEstados");
        });

        modelBuilder.Entity<Padre>(entity =>
        {
            entity.HasKey(e => e.Idpadres).HasName("PRIMARY");

            entity.ToTable("padres");

            entity.HasIndex(e => e.IdDirecciones, "idDirecciones_idx");

            entity.Property(e => e.Idpadres).HasColumnName("idpadres");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");
            entity.Property(e => e.IdDirecciones).HasColumnName("idDirecciones");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdDireccionesNavigation).WithMany(p => p.Padres)
                .HasForeignKey(d => d.IdDirecciones)
                .HasConstraintName("idDirecciones2");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Idpagos).HasName("PRIMARY");

            entity.ToTable("pagos");

            entity.HasIndex(e => e.IdAlumnos, "idAlumnos_idx");

            entity.Property(e => e.Idpagos).HasColumnName("idpagos");
            entity.Property(e => e.Concepto)
                .HasMaxLength(100)
                .HasColumnName("concepto");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdAlumnos).HasColumnName("idAlumnos");
            entity.Property(e => e.Importe).HasColumnName("importe");
            entity.Property(e => e.MedioPago)
                .HasMaxLength(20)
                .HasColumnName("medioPago");

            entity.HasOne(d => d.IdAlumnosNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdAlumnos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("idAlumnos");
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.HasKey(e => e.Idpaises).HasName("PRIMARY");

            entity.ToTable("paises");

            entity.Property(e => e.Idpaises).HasColumnName("idpaises");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Username>(entity =>
        {
            entity.HasKey(e => e.Idusernames).HasName("PRIMARY");

            entity.ToTable("usernames");

            entity.HasIndex(e => e.Username1, "username_UNIQUE").IsUnique();

            entity.Property(e => e.Idusernames).HasColumnName("idusernames");
            entity.Property(e => e.IdAlumnos).HasColumnName("idAlumnos");
            entity.Property(e => e.Username1)
                .HasMaxLength(45)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
