using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CampusKey.Entidades.Models
{
    public partial class DB_CampusKey_DevContext : DbContext
    {
        public DB_CampusKey_DevContext()
        {
        }

        public DB_CampusKey_DevContext(DbContextOptions<DB_CampusKey_DevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AsignacionRolUsuario> AsignacionRolUsuario { get; set; }
        public virtual DbSet<AsignacionTipoHorario> AsignacionTipoHorario { get; set; }
        public virtual DbSet<AtributoCurso> AtributoCurso { get; set; }
        public virtual DbSet<AtributoPeriodoLectivo> AtributoPeriodoLectivo { get; set; }
        public virtual DbSet<Calendario> Calendario { get; set; }
        public virtual DbSet<CalendarioPlantillaHorario> CalendarioPlantillaHorario { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Dominio> Dominio { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<EmpleadoCurso> EmpleadoCurso { get; set; }
        public virtual DbSet<EmpleadoSeccion> EmpleadoSeccion { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<EstudianteCurso> EstudianteCurso { get; set; }
        public virtual DbSet<Funcionalidad> Funcionalidad { get; set; }
        public virtual DbSet<Grado> Grado { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Materia> Materia { get; set; }
        public virtual DbSet<OpcionesRol> OpcionesRol { get; set; }
        public virtual DbSet<Padre> Padre { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<PeriodoLectivo> PeriodoLectivo { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<PlantillaHorario> PlantillaHorario { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Seccion> Seccion { get; set; }
        public virtual DbSet<TipoAtributo> TipoAtributo { get; set; }
        public virtual DbSet<TipoHorario> TipoHorario { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=dbckdev.database.windows.net, 1433; Database=DB_CampusKey_Dev; User id=administrador; Password=C4mpu5.K3y.2020**; Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsignacionRolUsuario>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.IdRol })
                    .HasName("PK__Asignaci__179F5151918353F4");

                entity.ToTable("AsignacionRolUsuario", "Seguridad");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.IdRol).HasColumnName("idRol");
            });

            modelBuilder.Entity<AsignacionTipoHorario>(entity =>
            {
                entity.HasKey(e => e.IdAsignacionTipoHorario)
                    .HasName("Configuracion_AsignacionTipoHorario_PK");

                entity.ToTable("AsignacionTipoHorario", "Configuracion");

                entity.Property(e => e.IdAsignacionTipoHorario).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AtributoCurso>(entity =>
            {
                entity.HasKey(e => e.IdAtributoCurso)
                    .HasName("GestionEscolar_AtributoCurso_PK");

                entity.ToTable("AtributoCurso", "GestionEscolar");

                entity.Property(e => e.IdAtributoCurso).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AtributoPeriodoLectivo>(entity =>
            {
                entity.HasKey(e => new { e.IdAtributoPeriodoLectivo, e.IdPeriodoLectivo })
                    .HasName("PK__Atributo__57ADD507A0A75773");

                entity.ToTable("AtributoPeriodoLectivo", "GestionEscolar");

                entity.Property(e => e.Valor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPeriodoLectivoNavigation)
                    .WithMany(p => p.AtributoPeriodoLectivo)
                    .HasForeignKey(d => d.IdPeriodoLectivo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AtributoP__IdPer__339FAB6E");
            });

            modelBuilder.Entity<Calendario>(entity =>
            {
                entity.HasKey(e => e.IdCalendario)
                    .HasName("Configuracion_Calendario_PK");

                entity.ToTable("Calendario", "Configuracion");

                entity.Property(e => e.IdCalendario).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.NombreDia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDia)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CalendarioPlantillaHorario>(entity =>
            {
                entity.HasKey(e => new { e.IdCalendario, e.IdCurso, e.IdPlantillaHorario })
                    .HasName("Configuracion_CalendarioPlantillaHorario_PK");

                entity.ToTable("CalendarioPlantillaHorario", "Configuracion");

                entity.HasOne(d => d.IdCalendarioNavigation)
                    .WithMany(p => p.CalendarioPlantillaHorario)
                    .HasForeignKey(d => d.IdCalendario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdCalendario");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.CalendarioPlantillaHorario)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdCurso");

                entity.HasOne(d => d.IdPlantillaHorarioNavigation)
                    .WithMany(p => p.CalendarioPlantillaHorario)
                    .HasForeignKey(d => d.IdPlantillaHorario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IdPlantillaHorario");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("GestionEscolar_Curso_PK");

                entity.ToTable("Curso", "GestionEscolar");

                entity.Property(e => e.IdCurso).ValueGeneratedNever();

                entity.Property(e => e.Estado)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dominio>(entity =>
            {
                entity.HasKey(e => e.IdValorDominioGrado)
                    .HasName("GestionEscolar_Dominio_PK");

                entity.ToTable("Dominio", "GestionEscolar");

                entity.Property(e => e.IdValorDominioGrado).ValueGeneratedNever();

                entity.Property(e => e.Criterio)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dominio1)
                    .HasColumnName("Dominio")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("Core_Empleado_PK");

                entity.ToTable("Empleado", "Core");

                entity.Property(e => e.IdPersona).ValueGeneratedNever();

                entity.Property(e => e.AreaDependencia).HasMaxLength(20);

                entity.Property(e => e.Escolaridad).HasMaxLength(60);

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.FechaRetiro).HasColumnType("date");

                entity.Property(e => e.UsuarioLog)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmpleadoCurso>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("GestionEscolar_EmpleadoCurso_PK");

                entity.ToTable("EmpleadoCurso", "GestionEscolar");

                entity.Property(e => e.IdPersona).ValueGeneratedNever();
            });

            modelBuilder.Entity<EmpleadoSeccion>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("Core_EmpleadoSeccion_PK");

                entity.ToTable("EmpleadoSeccion", "Core");

                entity.Property(e => e.IdPersona).ValueGeneratedNever();
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("Core_Estudiante_PK");

                entity.ToTable("Estudiante", "Core");

                entity.Property(e => e.IdPersona)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Casa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaIngreso).HasColumnType("date");

                entity.Property(e => e.NombreResponsablePago)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacionAcudiente).HasMaxLength(100);

                entity.Property(e => e.ResponsablePago)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacionAcudiente).HasMaxLength(60);
            });

            modelBuilder.Entity<EstudianteCurso>(entity =>
            {
                entity.HasKey(e => e.IdAsignacion)
                    .HasName("GestionEscolar_EstudianteCurso_PK");

                entity.ToTable("EstudianteCurso", "GestionEscolar");

                entity.Property(e => e.IdAsignacion).ValueGeneratedNever();

                entity.Property(e => e.Estado).HasMaxLength(100);

                entity.Property(e => e.EstudiantePendienteCurso)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRetiro).HasColumnType("date");

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioLog)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Funcionalidad>(entity =>
            {
                entity.HasKey(e => e.IdFuncionalidad)
                    .HasName("PK__Funciona__047AABCE53705473");

                entity.ToTable("Funcionalidad", "Seguridad");

                entity.Property(e => e.IdFuncionalidad).HasColumnName("idFuncionalidad");

                entity.Property(e => e.EtiquetaHtml)
                    .HasColumnName("etiquetaHtml")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Imagen)
                    .HasColumnName("imagen")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Orden).HasColumnName("orden");

                entity.Property(e => e.Padre).HasColumnName("padre");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Grado>(entity =>
            {
                entity.HasKey(e => e.IdGrado)
                    .HasName("GestionEscolar_Grado_PK");

                entity.ToTable("Grado", "GestionEscolar");

                entity.Property(e => e.IdGrado).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => new { e.Idcurso, e.Idmateria })
                    .HasName("Configuracion.Horario_PK");

                entity.ToTable("Horario", "Configuracion");

                entity.Property(e => e.Idcurso).HasColumnName("idcurso");

                entity.Property(e => e.Idmateria).HasColumnName("idmateria");

                entity.Property(e => e.Dia).HasColumnName("dia");

                entity.Property(e => e.Hora).HasColumnName("hora");
            });

            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Materia", "GestionEscolar");

                entity.Property(e => e.IdMateria).ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(120)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OpcionesRol>(entity =>
            {
                entity.HasKey(e => new { e.IdRol, e.IdFuncionalidad })
                    .HasName("PK__Opciones__CCC085CABA2BE09E");

                entity.ToTable("OpcionesRol", "Seguridad");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.IdFuncionalidad).HasColumnName("idFuncionalidad");

                entity.Property(e => e.Permiso)
                    .HasColumnName("permiso")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFuncionalidadNavigation)
                    .WithMany(p => p.OpcionesRol)
                    .HasForeignKey(d => d.IdFuncionalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OpcionesR__idFun__5441852A");
            });

            modelBuilder.Entity<Padre>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("Core_Padre_PK");

                entity.ToTable("Padre", "Core");

                entity.Property(e => e.IdPersona).ValueGeneratedNever();

                entity.Property(e => e.Cargo).HasMaxLength(200);

                entity.Property(e => e.Empresa).HasMaxLength(200);

                entity.Property(e => e.Escolaridad).HasMaxLength(60);

                entity.Property(e => e.Ocupacion).HasMaxLength(200);

                entity.Property(e => e.SectorEconomico)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoOficina).HasMaxLength(100);

                entity.Property(e => e.TipoPadre).HasMaxLength(60);

                entity.Property(e => e.Titulo).HasMaxLength(400);

                entity.Property(e => e.UltimoGrado).HasMaxLength(60);

                entity.Property(e => e.UsuarioLog)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasKey(e => e.IdParametro)
                    .HasName("PK__Parametr__9C816E5FFD8C8460");

                entity.ToTable("Parametro", "Configuracion");

                entity.Property(e => e.IdParametro)
                    .HasColumnName("idParametro")
                    .ValueGeneratedNever();

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Grupo)
                    .HasColumnName("grupo")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDato)
                    .HasColumnName("tipoDato")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasColumnName("valor")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PeriodoLectivo>(entity =>
            {
                entity.HasKey(e => e.IdPeriodoLectivo)
                    .HasName("GestionEscolar_PeriodoLectivo_PK");

                entity.ToTable("PeriodoLectivo", "GestionEscolar");

                entity.Property(e => e.IdPeriodoLectivo).ValueGeneratedNever();

                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaInicio).HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("Core_Persona_PK");

                entity.ToTable("Persona", "Core");

                entity.Property(e => e.IdPersona).ValueGeneratedNever();

                entity.Property(e => e.Celular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoAlternativo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Genero)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PaisNacimiento)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UrlFoto)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PlantillaHorario>(entity =>
            {
                entity.HasKey(e => e.IdPlantillaHorario)
                    .HasName("Configuracion_PlantillaHorario_PK");

                entity.ToTable("PlantillaHorario", "Configuracion");

                entity.Property(e => e.IdPlantillaHorario).ValueGeneratedNever();

                entity.Property(e => e.TipoHora)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__3C872F76F217A36E");

                entity.ToTable("Rol", "Seguridad");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.IdFuncionalidad).HasColumnName("idFuncionalidad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoRol)
                    .HasColumnName("tipoRol")
                    .HasMaxLength(5)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Seccion>(entity =>
            {
                entity.HasKey(e => e.IdSeccion)
                    .HasName("GestionEscolar_Seccion_PK");

                entity.ToTable("Seccion", "GestionEscolar");

                entity.Property(e => e.IdSeccion).ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoAtributo>(entity =>
            {
                entity.HasKey(e => e.IdTipoAtributo)
                    .HasName("GestionEscolar_TipoAtributo_PK");

                entity.ToTable("TipoAtributo", "GestionEscolar");

                entity.Property(e => e.IdTipoAtributo).ValueGeneratedNever();

                entity.Property(e => e.Dominio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Entidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoHorario>(entity =>
            {
                entity.HasKey(e => e.IdTipoHorario)
                    .HasName("Configuracion_TipoHorario_PK");

                entity.ToTable("TipoHorario", "Configuracion");

                entity.Property(e => e.TipoHora)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A684743CAE");

                entity.ToTable("Usuario", "Seguridad");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("idUsuario")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .HasColumnName("displayName")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
