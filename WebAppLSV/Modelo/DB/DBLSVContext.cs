using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppLSV.Modelo.DB
{
    public partial class DBLSVContext : DbContext
    {
        public DBLSVContext()
        {
        }

        public DBLSVContext(DbContextOptions<DBLSVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Controlarchivo> Controlarchivo { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Detallecontrolarchivo> Detallecontrolarchivo { get; set; }
        public virtual DbSet<Documentosecretaria> Documentosecretaria { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<Estudiantecurso> Estudiantecurso { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Rolusuario> Rolusuario { get; set; }
        public virtual DbSet<Tipoparametro> Tipoparametro { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Valorparametro> Valorparametro { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DBLSV;Integrated Security=True");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Controlarchivo>(entity =>
            {
                entity.ToTable("CONTROLARCHIVO");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCargar)
                    .HasColumnName("Fecha_Cargar")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaProceso)
                    .HasColumnName("Fecha_Proceso")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.ToTable("CURSO");

                entity.Property(e => e.Identificador)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Detallecontrolarchivo>(entity =>
            {
                entity.ToTable("DETALLECONTROLARCHIVO");

                entity.Property(e => e.Apellido1)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido2)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Codestudiante)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Curso)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DescOficinaOrigen)
                    .IsRequired()
                    .HasColumnName("Desc_Oficina_Origen")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreps)
                    .IsRequired()
                    .HasColumnName("Fecha_Creps")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFacturacion)
                    .IsRequired()
                    .HasColumnName("Fecha_Facturacion")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroOrden)
                    .IsRequired()
                    .HasColumnName("Numero_Orden")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OficinaDestino)
                    .IsRequired()
                    .HasColumnName("Oficina_Destino")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OficinaOrigen)
                    .IsRequired()
                    .HasColumnName("Oficina_Origen")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Proyecto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Tipodoc)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ValorComision)
                    .IsRequired()
                    .HasColumnName("Valor_Comision")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ValorIva)
                    .IsRequired()
                    .HasColumnName("Valor_Iva")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ValorMovilizado)
                    .IsRequired()
                    .HasColumnName("Valor_Movilizado")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdControlarchivoNavigation)
                    .WithMany(p => p.Detallecontrolarchivo)
                    .HasForeignKey(d => d.IdControlarchivo)
                    .HasConstraintName("FK_DETALLE_CONTROL_ARCHIVO");
            });

            modelBuilder.Entity<Documentosecretaria>(entity =>
            {
                entity.ToTable("DOCUMENTOSECRETARIA");

                entity.Property(e => e.Cantidad)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEntrega)
                    .HasColumnName("Fecha_Entrega")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaSolicitud)
                    .HasColumnName("Fecha_Solicitud")
                    .HasColumnType("datetime");

                entity.Property(e => e.NombreSolicitante)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Observaciones)
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonosSolicitante)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TipoDocumento)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ValorAño)
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Documentosecretaria)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK_DOCUMENTOSECRETARIA_CURSO");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Documentosecretaria)
                    .HasForeignKey(d => d.IdEstudiante)
                    .HasConstraintName("FK_DOCUMENTOSECRETARIA_ESTUDIANTE");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.ToTable("ESTUDIANTE");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("APELLIDO")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasColumnName("DOCUMENTO")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("ESTADO")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("NOMBRE")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Tipodoc)
                    .IsRequired()
                    .HasColumnName("TIPODOC")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estudiantecurso>(entity =>
            {
                entity.ToTable("ESTUDIANTECURSO");

                entity.HasIndex(e => new { e.IdEstudiante, e.IdCurso })
                    .HasName("UK_ESTUDIANTECURSO")
                    .IsUnique();

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Estudiantecurso)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK_ESTUDIANTECURSO_CURSO");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Estudiantecurso)
                    .HasForeignKey(d => d.IdEstudiante)
                    .HasConstraintName("FK_ESTUDIANTECURSO_ESTUDIANTE");
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.ToTable("PARAMETRO");

                entity.HasIndex(e => e.Nombre)
                    .HasName("UK_NOMBRE_PARAMETRO")
                    .IsUnique();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoParametroNavigation)
                    .WithMany(p => p.Parametro)
                    .HasForeignKey(d => d.IdTipoParametro)
                    .HasConstraintName("FK_PARAMETRO_TIPO_PARAMETRO");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("ROL");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rolusuario>(entity =>
            {
                entity.ToTable("ROLUSUARIO");

                entity.Property(e => e.IdRol).HasDefaultValueSql("((3))");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Rolusuario)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_USUARIOROL_ROL");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Rolusuario)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_USUARIOROL_USUARIO");
            });

            modelBuilder.Entity<Tipoparametro>(entity =>
            {
                entity.ToTable("TIPOPARAMETRO");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Usuario1)
                    .HasName("UK_USUARIO")
                    .IsUnique();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Passwd)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .IsRequired()
                    .HasColumnName("Usuario")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Valorparametro>(entity =>
            {
                entity.ToTable("VALORPARAMETRO");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaIni).HasColumnType("datetime");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdParametroNavigation)
                    .WithMany(p => p.Valorparametro)
                    .HasForeignKey(d => d.IdParametro)
                    .HasConstraintName("FK_PARAMETRO_VALOR_PARAMETRO");
            });

            modelBuilder.Query<LoginByUsernamePassword>();
            modelBuilder.Query<ProcesarArchivo>();
        }

        public async Task<List<LoginByUsernamePassword>> LoginByUsernamePasswordMethodAsync(string usernameVal, string passwordVal)
        {
            List<LoginByUsernamePassword> lst = new List<LoginByUsernamePassword>();

            try
            {

                SqlParameter usernameParam = new SqlParameter("@username", usernameVal ?? (object)DBNull.Value);
                SqlParameter passwordParam = new SqlParameter("@password", passwordVal ?? (object)DBNull.Value);


                string sqlQuery = "EXEC [dbo].[LoginByUsernamePassword] " +
                                    "@username, @password";

                lst = await Query<LoginByUsernamePassword>().FromSql(sqlQuery, usernameParam, passwordParam).ToListAsync();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                //throw ex;
            }


            return lst;
        }

  
    }
}
