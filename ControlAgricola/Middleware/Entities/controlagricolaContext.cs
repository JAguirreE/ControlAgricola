using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ControlAgricola.Middleware.Entities
{
    public partial class controlagricolaContext : DbContext
    {
        public controlagricolaContext()
        {
        }

        public controlagricolaContext(DbContextOptions<controlagricolaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<CategoriaProducto> CategoriaProducto { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<FacturaDetalle> FacturaDetalle { get; set; }
        public virtual DbSet<Finca> Finca { get; set; }
        public virtual DbSet<Lote> Lote { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<ProductoPermitido> ProductoPermitido { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<TipoActividad> TipoActividad { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;user=root;password=root;database=controlagricola;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Actividad>(entity =>
            {
                entity.HasKey(e => e.IdActividad);

                entity.ToTable("actividad", "controlagricola");

                entity.HasIndex(e => e.IdLote)
                    .HasName("FK_actividad_id_lote");

                entity.HasIndex(e => e.IdPermiso)
                    .HasName("FK_actividad_id_permiso");

                entity.HasIndex(e => e.IdProducto)
                    .HasName("FK_actividad_id_producto");

                entity.HasIndex(e => e.IdTipoActividad)
                    .HasName("FK_actividad_id_tipo_actividad");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("FK_actividad_id_usuario");

                entity.Property(e => e.IdActividad)
                    .HasColumnName("id_actividad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("decimal(10,0)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("date");

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasColumnName("foto")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdLote)
                    .HasColumnName("id_lote")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdPermiso)
                    .HasColumnName("id_permiso")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdTipoActividad)
                    .HasColumnName("id_tipo_actividad")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Meteorologia)
                    .IsRequired()
                    .HasColumnName("meteorologia")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MetodoAplicacion)
                    .IsRequired()
                    .HasColumnName("metodo_aplicacion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdLoteNavigation)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.IdLote)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_actividad_id_lote");

                entity.HasOne(d => d.IdPermisoNavigation)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.IdPermiso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_actividad_id_permiso");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_actividad_id_producto");

                entity.HasOne(d => d.IdTipoActividadNavigation)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.IdTipoActividad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_actividad_id_tipo_actividad");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Actividad)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_actividad_id_usuario");
            });

            modelBuilder.Entity<CategoriaProducto>(entity =>
            {
                entity.HasKey(e => e.IdCategoria);

                entity.ToTable("categoria_producto", "controlagricola");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFac);

                entity.ToTable("factura", "controlagricola");

                entity.Property(e => e.IdFac)
                    .HasColumnName("id_fac")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Emisor)
                    .IsRequired()
                    .HasColumnName("emisor")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasColumnType("char(3)");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnName("numero")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Receptor)
                    .IsRequired()
                    .HasColumnName("receptor")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ValorBase)
                    .HasColumnName("valor_base")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.ValorImpuestos)
                    .HasColumnName("valor_impuestos")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.ValorTotal)
                    .HasColumnName("valor_total")
                    .HasColumnType("decimal(10,0)");
            });

            modelBuilder.Entity<FacturaDetalle>(entity =>
            {
                entity.HasKey(e => e.IdDetFac);

                entity.ToTable("factura_detalle", "controlagricola");

                entity.HasIndex(e => e.IdFac)
                    .HasName("FK_factura_detalle_id_fac");

                entity.Property(e => e.IdDetFac)
                    .HasColumnName("id_det_fac")
                    .HasColumnType("bigint(20)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cantidad)
                    .HasColumnName("cantidad")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.Concepto)
                    .IsRequired()
                    .HasColumnName("concepto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasColumnType("char(3)");

                entity.Property(e => e.IdFac)
                    .HasColumnName("id_fac")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Subtotal)
                    .HasColumnName("subtotal")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.ValorUnidad)
                    .HasColumnName("valor_unidad")
                    .HasColumnType("decimal(10,0)");

                entity.HasOne(d => d.IdFacNavigation)
                    .WithMany(p => p.FacturaDetalle)
                    .HasForeignKey(d => d.IdFac)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_factura_detalle_id_fac");
            });

            modelBuilder.Entity<Finca>(entity =>
            {
                entity.HasKey(e => e.IdFinca);

                entity.ToTable("finca", "controlagricola");

                entity.Property(e => e.IdFinca)
                    .HasColumnName("id_finca")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasColumnName("direccion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tamano)
                    .IsRequired()
                    .HasColumnName("tamano")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.HasKey(e => e.IdLote);

                entity.ToTable("lote", "controlagricola");

                entity.HasIndex(e => e.IdFinca)
                    .HasName("FK_lote_id_finca");

                entity.Property(e => e.IdLote)
                    .HasColumnName("id_lote")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdFinca)
                    .HasColumnName("id_finca")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tamano)
                    .IsRequired()
                    .HasColumnName("tamano")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdFincaNavigation)
                    .WithMany(p => p.Lote)
                    .HasForeignKey(d => d.IdFinca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_lote_id_finca");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso);

                entity.ToTable("permiso", "controlagricola");

                entity.HasIndex(e => e.IdCategoria)
                    .HasName("FK_permiso_id_categoria");

                entity.Property(e => e.IdPermiso)
                    .HasColumnName("id_permiso")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasColumnName("numero")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Permiso)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_permiso_id_categoria");
            });

            modelBuilder.Entity<ProductoPermitido>(entity =>
            {
                entity.HasKey(e => e.IdProducto);

                entity.ToTable("producto_permitido", "controlagricola");

                entity.HasIndex(e => e.IdCategoria)
                    .HasName("FK_producto_id_categoria");

                entity.Property(e => e.IdProducto)
                    .HasColumnName("id_producto")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.ProductoPermitido)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_producto_id_categoria");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("rol", "controlagricola");

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoActividad>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.ToTable("tipo_actividad", "controlagricola");

                entity.Property(e => e.IdTipo)
                    .HasColumnName("id_tipo")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("usuario", "controlagricola");

                entity.HasIndex(e => e.IdRol)
                    .HasName("FK_usuario_id_rol");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Documento)
                    .IsRequired()
                    .HasColumnName("documento")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.IdRol)
                    .HasColumnName("id_rol")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK_usuario_id_rol");
            });
        }
    }
}
