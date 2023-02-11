using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Lourtec.WebAppInventario.Models;

namespace Lourtec.WebAppInventario.DAL.DataContext;

public partial class DbwebInventarioContext : DbContext
{
    public DbwebInventarioContext()
    {
    }

    public DbwebInventarioContext(DbContextOptions<DbwebInventarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bodega> Bodegas { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<CondicionPago> CondicionPagos { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Existencium> Existencia { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<Ingreso> Ingresos { get; set; }

    public virtual DbSet<IngresoDetalle> IngresoDetalles { get; set; }

    public virtual DbSet<Linea> Lineas { get; set; }

    public virtual DbSet<LineaCompra> LineaCompras { get; set; }

    public virtual DbSet<LineaSalidum> LineaSalida { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Medidum> Medida { get; set; }

    public virtual DbSet<Motivo> Motivos { get; set; }

    public virtual DbSet<OrdenCompra> OrdenCompras { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Provincium> Provincia { get; set; }

    public virtual DbSet<Requisicion> Requisicions { get; set; }

    public virtual DbSet<Salidum> Salida { get; set; }

    public virtual DbSet<Tipo> Tipos { get; set; }

    public virtual DbSet<TipoPersona> TipoPersonas { get; set; }

    public virtual DbSet<TipoProveedor> TipoProveedors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bodega>(entity =>
        {
            entity.HasKey(e => e.BodegaId).HasName("PK__Bodega__37A29A755DF4296C");

            entity.ToTable("Bodega");

            entity.Property(e => e.BodegaId)
                .ValueGeneratedNever()
                .HasColumnName("BodegaID");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.ProvinciaId).HasColumnName("ProvinciaID");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Bodegas)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__Bodega__EmpresaI__74AE54BC");

            entity.HasOne(d => d.Estado).WithMany(p => p.Bodegas)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Bodega__EstadoID__76969D2E");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Bodegas)
                .HasForeignKey(d => d.ProvinciaId)
                .HasConstraintName("FK__Bodega__Provinci__75A278F5");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__Color__8DA7676DD27846B1");

            entity.ToTable("Color");

            entity.Property(e => e.ColorId)
                .ValueGeneratedNever()
                .HasColumnName("ColorID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Producto).WithMany(p => p.Colors)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Color__ProductoI__07C12930");
        });

        modelBuilder.Entity<CondicionPago>(entity =>
        {
            entity.HasKey(e => e.CondicionPagoId).HasName("PK__Condicio__586DA44F332876FA");

            entity.ToTable("CondicionPago");

            entity.Property(e => e.CondicionPagoId)
                .ValueGeneratedNever()
                .HasColumnName("CondicionPagoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.EmpresaId).HasName("PK__Empresa__7B9F213663C22DF9");

            entity.ToTable("Empresa");

            entity.HasIndex(e => e.Correo, "UQ__Empresa__60695A1919D7140E").IsUnique();

            entity.Property(e => e.EmpresaId)
                .ValueGeneratedNever()
                .HasColumnName("EmpresaID");
            entity.Property(e => e.Correo)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(255);
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Estado__FEF86B60C23B0EF7");

            entity.ToTable("Estado");

            entity.Property(e => e.EstadoId)
                .ValueGeneratedNever()
                .HasColumnName("EstadoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Existencium>(entity =>
        {
            entity.HasKey(e => e.ExistenciaId).HasName("PK__Existenc__A23A887E621DDB7C");

            entity.Property(e => e.ExistenciaId)
                .ValueGeneratedNever()
                .HasColumnName("ExistenciaID");
            entity.Property(e => e.BodegaId).HasColumnName("BodegaID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Bodega).WithMany(p => p.Existencia)
                .HasForeignKey(d => d.BodegaId)
                .HasConstraintName("FK__Existenci__Bodeg__02FC7413");

            entity.HasOne(d => d.Producto).WithMany(p => p.Existencia)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Existenci__Produ__02084FDA");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.GrupoId).HasName("PK__Grupo__556BF0605AE10679");

            entity.ToTable("Grupo");

            entity.Property(e => e.GrupoId)
                .ValueGeneratedNever()
                .HasColumnName("GrupoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.HasKey(e => e.IngresoId).HasName("PK__Ingreso__DBF090BA95FF3F39");

            entity.ToTable("Ingreso");

            entity.HasIndex(e => e.CodigoIngreso, "UQ__Ingreso__31F11754EB8A765A").IsUnique();

            entity.Property(e => e.IngresoId)
                .ValueGeneratedNever()
                .HasColumnName("IngresoID");
            entity.Property(e => e.BodegaId).HasColumnName("BodegaID");
            entity.Property(e => e.CodigoIngreso).ValueGeneratedOnAdd();
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MotivoId).HasColumnName("MotivoID");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

            entity.HasOne(d => d.Bodega).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.BodegaId)
                .HasConstraintName("FK__Ingreso__BodegaI__7B5B524B");

            entity.HasOne(d => d.Motivo).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.MotivoId)
                .HasConstraintName("FK__Ingreso__MotivoI__7A672E12");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK__Ingreso__Proveed__797309D9");
        });

        modelBuilder.Entity<IngresoDetalle>(entity =>
        {
            entity.HasKey(e => e.IngresoDetalleId).HasName("PK__IngresoD__A917DA72C391BBD3");

            entity.ToTable("IngresoDetalle");

            entity.Property(e => e.IngresoDetalleId)
                .ValueGeneratedNever()
                .HasColumnName("IngresoDetalleID");
            entity.Property(e => e.IngresoId).HasColumnName("IngresoID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Ingreso).WithMany(p => p.IngresoDetalles)
                .HasForeignKey(d => d.IngresoId)
                .HasConstraintName("FK__IngresoDe__Ingre__7D439ABD");

            entity.HasOne(d => d.Producto).WithMany(p => p.IngresoDetalles)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__IngresoDe__Produ__7C4F7684");
        });

        modelBuilder.Entity<Linea>(entity =>
        {
            entity.HasKey(e => e.LineaId).HasName("PK__Linea__78106D1131F51D10");

            entity.ToTable("Linea");

            entity.Property(e => e.LineaId)
                .ValueGeneratedNever()
                .HasColumnName("LineaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<LineaCompra>(entity =>
        {
            entity.HasKey(e => e.LineaCompraId).HasName("PK__LineaCom__527F98BC76CE3C04");

            entity.ToTable("LineaCompra");

            entity.Property(e => e.LineaCompraId)
                .ValueGeneratedNever()
                .HasColumnName("LineaCompraID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.OrdenCompraId).HasColumnName("OrdenCompraID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.OrdenCompra).WithMany(p => p.LineaCompras)
                .HasForeignKey(d => d.OrdenCompraId)
                .HasConstraintName("FK__LineaComp__Orden__03F0984C");

            entity.HasOne(d => d.Producto).WithMany(p => p.LineaCompras)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__LineaComp__Produ__04E4BC85");
        });

        modelBuilder.Entity<LineaSalidum>(entity =>
        {
            entity.HasKey(e => e.LineaSalidaId).HasName("PK__LineaSal__DE2C0D9840390BBF");

            entity.Property(e => e.LineaSalidaId)
                .ValueGeneratedNever()
                .HasColumnName("LineaSalidaID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.SalidaId).HasColumnName("SalidaID");

            entity.HasOne(d => d.Producto).WithMany(p => p.LineaSalida)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__LineaSali__Produ__06CD04F7");

            entity.HasOne(d => d.Salida).WithMany(p => p.LineaSalida)
                .HasForeignKey(d => d.SalidaId)
                .HasConstraintName("FK__LineaSali__Salid__05D8E0BE");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("PK__Marca__D5B1CDEB96EDF7A8");

            entity.ToTable("Marca");

            entity.Property(e => e.MarcaId)
                .ValueGeneratedNever()
                .HasColumnName("MarcaID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Producto).WithMany(p => p.Marcas)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Marca__ProductoI__08B54D69");
        });

        modelBuilder.Entity<Medidum>(entity =>
        {
            entity.HasKey(e => e.MedidaId).HasName("PK__Medida__5F7A0CE2503FEA31");

            entity.Property(e => e.MedidaId)
                .ValueGeneratedNever()
                .HasColumnName("MedidaID");
            entity.Property(e => e.Dimension).HasMaxLength(255);
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Producto).WithMany(p => p.Medida)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Medida__Producto__09A971A2");
        });

        modelBuilder.Entity<Motivo>(entity =>
        {
            entity.HasKey(e => e.MotivoId).HasName("PK__Motivo__AE78D2571174E1F4");

            entity.ToTable("Motivo");

            entity.Property(e => e.MotivoId)
                .ValueGeneratedNever()
                .HasColumnName("MotivoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<OrdenCompra>(entity =>
        {
            entity.HasKey(e => e.OrdenCompraId).HasName("PK__OrdenCom__0B556E160F33F920");

            entity.ToTable("OrdenCompra");

            entity.Property(e => e.OrdenCompraId)
                .ValueGeneratedNever()
                .HasColumnName("OrdenCompraID");
            entity.Property(e => e.CondicionPagoId).HasColumnName("CondicionPagoID");
            entity.Property(e => e.Observacion).HasColumnType("text");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.Referencia).HasMaxLength(255);

            entity.HasOne(d => d.CondicionPago).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.CondicionPagoId)
                .HasConstraintName("FK__OrdenComp__Condi__787EE5A0");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.OrdenCompras)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK__OrdenComp__Prove__778AC167");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE83CCB5342B");

            entity.ToTable("Producto");

            entity.Property(e => e.ProductoId)
                .ValueGeneratedNever()
                .HasColumnName("ProductoID");
            entity.Property(e => e.Codigo).ValueGeneratedOnAdd();
            entity.Property(e => e.Comentario).HasColumnType("text");
            entity.Property(e => e.FechaCaducidad).HasColumnType("datetime");
            entity.Property(e => e.Iva).HasColumnName("IVA");
            entity.Property(e => e.LineaId).HasColumnName("LineaID");
            entity.Property(e => e.Perecible).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.GrupoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Grupo)
                .HasConstraintName("FK__Producto__Grupo__6EF57B66");

            entity.HasOne(d => d.Linea).WithMany(p => p.Productos)
                .HasForeignKey(d => d.LineaId)
                .HasConstraintName("FK__Producto__LineaI__6D0D32F4");

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Tipo)
                .HasConstraintName("FK__Producto__Tipo__6E01572D");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PK__Proveedo__61266BB9653746EC");

            entity.ToTable("Proveedor");

            entity.HasIndex(e => e.Codigo, "UQ__Proveedo__06370DAC83D8D39C").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Proveedo__A9D10534C6FA52B7").IsUnique();

            entity.Property(e => e.ProveedorId)
                .ValueGeneratedNever()
                .HasColumnName("ProveedorID");
            entity.Property(e => e.Codigo).ValueGeneratedOnAdd();
            entity.Property(e => e.Contacto).HasMaxLength(255);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.PaginaWeb).HasMaxLength(255);
            entity.Property(e => e.Plazo).HasColumnType("datetime");
            entity.Property(e => e.ProvinciaId).HasColumnName("ProvinciaID");
            entity.Property(e => e.RazonSocial).HasMaxLength(255);
            entity.Property(e => e.Ruc)
                .HasMaxLength(255)
                .HasColumnName("RUC");
            entity.Property(e => e.Telefono).HasMaxLength(255);
            entity.Property(e => e.TipoProveedorId).HasColumnName("TipoProveedorID");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__Proveedor__Empre__6FE99F9F");

            entity.HasOne(d => d.Estado).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Proveedor__Estad__72C60C4A");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.ProvinciaId)
                .HasConstraintName("FK__Proveedor__Provi__71D1E811");

            entity.HasOne(d => d.TipoPersonaNavigation).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.TipoPersona)
                .HasConstraintName("FK__Proveedor__TipoP__73BA3083");

            entity.HasOne(d => d.TipoProveedor).WithMany(p => p.Proveedors)
                .HasForeignKey(d => d.TipoProveedorId)
                .HasConstraintName("FK__Proveedor__TipoP__70DDC3D8");
        });

        modelBuilder.Entity<Provincium>(entity =>
        {
            entity.HasKey(e => e.ProvinciaId).HasName("PK__Provinci__F7CBC757A471C4F9");

            entity.Property(e => e.ProvinciaId)
                .ValueGeneratedNever()
                .HasColumnName("ProvinciaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Requisicion>(entity =>
        {
            entity.HasKey(e => e.RequisicionId).HasName("PK__Requisic__BF9D0918F291F453");

            entity.ToTable("Requisicion");

            entity.HasIndex(e => e.CodigoRequisicion, "UQ__Requisic__5DC360DE08F16114").IsUnique();

            entity.Property(e => e.RequisicionId)
                .ValueGeneratedNever()
                .HasColumnName("RequisicionID");
            entity.Property(e => e.CodigoRequisicion).ValueGeneratedOnAdd();
            entity.Property(e => e.Comentario).HasMaxLength(255);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Solicitado).HasMaxLength(255);
        });

        modelBuilder.Entity<Salidum>(entity =>
        {
            entity.HasKey(e => e.SalidaId).HasName("PK__Salida__DC9971032C5BEA2E");

            entity.HasIndex(e => e.Codigo, "UQ__Salida__06370DAC6FB242D0").IsUnique();

            entity.Property(e => e.SalidaId)
                .ValueGeneratedNever()
                .HasColumnName("SalidaID");
            entity.Property(e => e.BodegaId).HasColumnName("BodegaID");
            entity.Property(e => e.Codigo).ValueGeneratedOnAdd();
            entity.Property(e => e.Comentario).HasColumnType("text");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MotivoId).HasColumnName("MotivoID");
            entity.Property(e => e.RequisicionId).HasColumnName("RequisicionID");

            entity.HasOne(d => d.Bodega).WithMany(p => p.Salida)
                .HasForeignKey(d => d.BodegaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Salida__BodegaID__00200768");

            entity.HasOne(d => d.Motivo).WithMany(p => p.Salida)
                .HasForeignKey(d => d.MotivoId)
                .HasConstraintName("FK__Salida__MotivoID__7E37BEF6");

            entity.HasOne(d => d.Requisicion).WithMany(p => p.Salida)
                .HasForeignKey(d => d.RequisicionId)
                .HasConstraintName("FK__Salida__Requisic__7F2BE32F");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.TipoId).HasName("PK__Tipo__97099E9765574284");

            entity.ToTable("Tipo");

            entity.Property(e => e.TipoId)
                .ValueGeneratedNever()
                .HasColumnName("TipoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoPersona>(entity =>
        {
            entity.HasKey(e => e.TipoPersonaId).HasName("PK__TipoPers__485B78287FDC4A1D");

            entity.ToTable("TipoPersona");

            entity.Property(e => e.TipoPersonaId)
                .ValueGeneratedNever()
                .HasColumnName("TipoPersonaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoProveedor>(entity =>
        {
            entity.HasKey(e => e.TipoProveedorId).HasName("PK__TipoProv__4F47792034A04C79");

            entity.ToTable("TipoProveedor");

            entity.Property(e => e.TipoProveedorId)
                .ValueGeneratedNever()
                .HasColumnName("TipoProveedorID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE79899A11CD5");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A19B8AC659E").IsUnique();

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasColumnName("UsuarioID");
            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.Password).HasMaxLength(255);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__Usuario__Empresa__01142BA1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
