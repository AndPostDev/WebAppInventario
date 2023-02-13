using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Lourtec.WebAppInventario.Models;

namespace Lourtec.WebAppInventario.DAL.DataContext;

public partial class DbInventarioContext : DbContext
{
    public DbInventarioContext()
    {
    }

    public DbInventarioContext(DbContextOptions<DbInventarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bodega> Bodega { get; set; }

    public virtual DbSet<Color> Color { get; set; }

    public virtual DbSet<CondicionPago> CondicionPago { get; set; }

    public virtual DbSet<Empresa> Empresa { get; set; }

    public virtual DbSet<Estado> Estado { get; set; }

    public virtual DbSet<Existencia> Existencia { get; set; }

    public virtual DbSet<Grupo> Grupo { get; set; }

    public virtual DbSet<Ingreso> Ingreso { get; set; }

    public virtual DbSet<IngresoDetalle> IngresoDetalle { get; set; }

    public virtual DbSet<Linea> Linea { get; set; }

    public virtual DbSet<LineaCompra> LineaCompra { get; set; }

    public virtual DbSet<LineaSalida> LineaSalida { get; set; }

    public virtual DbSet<Marca> Marca { get; set; }

    public virtual DbSet<Medida> Medida { get; set; }

    public virtual DbSet<Motivo> Motivo { get; set; }

    public virtual DbSet<OrdenCompra> OrdenCompra { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Proveedor> Proveedor { get; set; }

    public virtual DbSet<Provincia> Provincia { get; set; }

    public virtual DbSet<Requisicion> Requisicion { get; set; }

    public virtual DbSet<Salida> Salida { get; set; }

    public virtual DbSet<Tipo> Tipo { get; set; }

    public virtual DbSet<TipoPersona> TipoPersona { get; set; }

    public virtual DbSet<TipoProveedor> TipoProveedor { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DbInventario;Trust Server Certificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bodega>(entity =>
        {
            entity.HasKey(e => e.BodegaId).HasName("PK__Bodega__37A29A75C30DC76F");

            entity.Property(e => e.BodegaId)
                .ValueGeneratedNever()
                .HasColumnName("BodegaID");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.ProvinciaId).HasColumnName("ProvinciaID");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Bodega)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__Bodega__EmpresaI__619B8048");

            entity.HasOne(d => d.Estado).WithMany(p => p.Bodega)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Bodega__EstadoID__6383C8BA");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Bodega)
                .HasForeignKey(d => d.ProvinciaId)
                .HasConstraintName("FK__Bodega__Provinci__628FA481");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__Color__8DA7676D5A913F4E");

            entity.Property(e => e.ColorId)
                .ValueGeneratedNever()
                .HasColumnName("ColorID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Producto).WithMany(p => p.Color)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Color__ProductoI__74AE54BC");
        });

        modelBuilder.Entity<CondicionPago>(entity =>
        {
            entity.HasKey(e => e.CondicionPagoId).HasName("PK__Condicio__586DA44F6C3B34F5");

            entity.Property(e => e.CondicionPagoId)
                .ValueGeneratedNever()
                .HasColumnName("CondicionPagoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.EmpresaId).HasName("PK__Empresa__7B9F2136539750B3");

            entity.HasIndex(e => e.Correo, "UQ__Empresa__60695A19F0FEDF0A").IsUnique();

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
            entity.HasKey(e => e.EstadoId).HasName("PK__Estado__FEF86B6003FDD69E");

            entity.Property(e => e.EstadoId)
                .ValueGeneratedNever()
                .HasColumnName("EstadoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Existencia>(entity =>
        {
            entity.HasKey(e => e.ExistenciaId).HasName("PK__Existenc__A23A887EA3E8CA68");

            entity.Property(e => e.ExistenciaId)
                .ValueGeneratedNever()
                .HasColumnName("ExistenciaID");
            entity.Property(e => e.BodegaId).HasColumnName("BodegaID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Bodega).WithMany(p => p.Existencia)
                .HasForeignKey(d => d.BodegaId)
                .HasConstraintName("FK__Existenci__Bodeg__6FE99F9F");

            entity.HasOne(d => d.Producto).WithMany(p => p.Existencia)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Existenci__Produ__6EF57B66");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.GrupoId).HasName("PK__Grupo__556BF0609B42A48D");

            entity.Property(e => e.GrupoId)
                .ValueGeneratedNever()
                .HasColumnName("GrupoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.HasKey(e => e.IngresoId).HasName("PK__Ingreso__DBF090BAE77CB185");

            entity.HasIndex(e => e.CodigoIngreso, "UQ__Ingreso__31F117540F91D981").IsUnique();

            entity.Property(e => e.IngresoId)
                .ValueGeneratedNever()
                .HasColumnName("IngresoID");
            entity.Property(e => e.BodegaId).HasColumnName("BodegaID");
            entity.Property(e => e.CodigoIngreso).ValueGeneratedOnAdd();
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MotivoId).HasColumnName("MotivoID");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

            entity.HasOne(d => d.Bodega).WithMany(p => p.Ingreso)
                .HasForeignKey(d => d.BodegaId)
                .HasConstraintName("FK__Ingreso__BodegaI__68487DD7");

            entity.HasOne(d => d.Motivo).WithMany(p => p.Ingreso)
                .HasForeignKey(d => d.MotivoId)
                .HasConstraintName("FK__Ingreso__MotivoI__6754599E");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Ingreso)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK__Ingreso__Proveed__66603565");
        });

        modelBuilder.Entity<IngresoDetalle>(entity =>
        {
            entity.HasKey(e => e.IngresoDetalleId).HasName("PK__IngresoD__A917DA72DD38A068");

            entity.Property(e => e.IngresoDetalleId)
                .ValueGeneratedNever()
                .HasColumnName("IngresoDetalleID");
            entity.Property(e => e.IngresoId).HasColumnName("IngresoID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Ingreso).WithMany(p => p.IngresoDetalle)
                .HasForeignKey(d => d.IngresoId)
                .HasConstraintName("FK__IngresoDe__Ingre__6A30C649");

            entity.HasOne(d => d.Producto).WithMany(p => p.IngresoDetalle)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__IngresoDe__Produ__693CA210");
        });

        modelBuilder.Entity<Linea>(entity =>
        {
            entity.HasKey(e => e.LineaId).HasName("PK__Linea__78106D117ABB97F8");

            entity.Property(e => e.LineaId)
                .ValueGeneratedNever()
                .HasColumnName("LineaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<LineaCompra>(entity =>
        {
            entity.HasKey(e => e.LineaCompraId).HasName("PK__LineaCom__527F98BCACB427EA");

            entity.Property(e => e.LineaCompraId)
                .ValueGeneratedNever()
                .HasColumnName("LineaCompraID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.OrdenCompraId).HasColumnName("OrdenCompraID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.OrdenCompra).WithMany(p => p.LineaCompra)
                .HasForeignKey(d => d.OrdenCompraId)
                .HasConstraintName("FK__LineaComp__Orden__70DDC3D8");

            entity.HasOne(d => d.Producto).WithMany(p => p.LineaCompra)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__LineaComp__Produ__71D1E811");
        });

        modelBuilder.Entity<LineaSalida>(entity =>
        {
            entity.HasKey(e => e.LineaSalidaId).HasName("PK__LineaSal__DE2C0D98ED453D9B");

            entity.Property(e => e.LineaSalidaId)
                .ValueGeneratedNever()
                .HasColumnName("LineaSalidaID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.SalidaId).HasColumnName("SalidaID");

            entity.HasOne(d => d.Producto).WithMany(p => p.LineaSalida)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__LineaSali__Produ__73BA3083");

            entity.HasOne(d => d.Salida).WithMany(p => p.LineaSalida)
                .HasForeignKey(d => d.SalidaId)
                .HasConstraintName("FK__LineaSali__Salid__72C60C4A");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("PK__Marca__D5B1CDEBFAA678B2");

            entity.Property(e => e.MarcaId)
                .ValueGeneratedNever()
                .HasColumnName("MarcaID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Producto).WithMany(p => p.Marca)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Marca__ProductoI__75A278F5");
        });

        modelBuilder.Entity<Medida>(entity =>
        {
            entity.HasKey(e => e.MedidaId).HasName("PK__Medida__5F7A0CE26669C469");

            entity.Property(e => e.MedidaId)
                .ValueGeneratedNever()
                .HasColumnName("MedidaID");
            entity.Property(e => e.Dimension).HasMaxLength(255);
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Producto).WithMany(p => p.Medida)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Medida__Producto__76969D2E");
        });

        modelBuilder.Entity<Motivo>(entity =>
        {
            entity.HasKey(e => e.MotivoId).HasName("PK__Motivo__AE78D257EFD23BE9");

            entity.Property(e => e.MotivoId)
                .ValueGeneratedNever()
                .HasColumnName("MotivoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<OrdenCompra>(entity =>
        {
            entity.HasKey(e => e.OrdenCompraId).HasName("PK__OrdenCom__0B556E164FAF14E9");

            entity.Property(e => e.OrdenCompraId)
                .ValueGeneratedNever()
                .HasColumnName("OrdenCompraID");
            entity.Property(e => e.CondicionPagoId).HasColumnName("CondicionPagoID");
            entity.Property(e => e.Observacion).HasColumnType("text");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.Referencia).HasMaxLength(255);

            entity.HasOne(d => d.CondicionPago).WithMany(p => p.OrdenCompra)
                .HasForeignKey(d => d.CondicionPagoId)
                .HasConstraintName("FK__OrdenComp__Condi__656C112C");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.OrdenCompra)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK__OrdenComp__Prove__6477ECF3");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE8365886284");

            entity.Property(e => e.ProductoId)
                .ValueGeneratedNever()
                .HasColumnName("ProductoID");
            entity.Property(e => e.Codigo).ValueGeneratedOnAdd();
            entity.Property(e => e.Comentario).HasColumnType("text");
            entity.Property(e => e.FechaCaducidad).HasColumnType("datetime");
            entity.Property(e => e.Iva).HasColumnName("IVA");
            entity.Property(e => e.LineaId).HasColumnName("LineaID");
            entity.Property(e => e.Perecible).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.GrupoNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.Grupo)
                .HasConstraintName("FK__Producto__Grupo__5BE2A6F2");

            entity.HasOne(d => d.Linea).WithMany(p => p.Producto)
                .HasForeignKey(d => d.LineaId)
                .HasConstraintName("FK__Producto__LineaI__59FA5E80");

            entity.HasOne(d => d.TipoNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.Tipo)
                .HasConstraintName("FK__Producto__Tipo__5AEE82B9");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PK__Proveedo__61266BB959A78B3D");

            entity.HasIndex(e => e.Codigo, "UQ__Proveedo__06370DAC5E62455F").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Proveedo__A9D10534321F1DC2").IsUnique();

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

            entity.HasOne(d => d.Empresa).WithMany(p => p.Proveedor)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__Proveedor__Empre__5CD6CB2B");

            entity.HasOne(d => d.Estado).WithMany(p => p.Proveedor)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Proveedor__Estad__5FB337D6");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Proveedor)
                .HasForeignKey(d => d.ProvinciaId)
                .HasConstraintName("FK__Proveedor__Provi__5EBF139D");

            entity.HasOne(d => d.TipoPersonaNavigation).WithMany(p => p.Proveedor)
                .HasForeignKey(d => d.TipoPersona)
                .HasConstraintName("FK__Proveedor__TipoP__60A75C0F");

            entity.HasOne(d => d.TipoProveedor).WithMany(p => p.Proveedor)
                .HasForeignKey(d => d.TipoProveedorId)
                .HasConstraintName("FK__Proveedor__TipoP__5DCAEF64");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.ProvinciaId).HasName("PK__Provinci__F7CBC75732ED89AB");

            entity.Property(e => e.ProvinciaId)
                .ValueGeneratedNever()
                .HasColumnName("ProvinciaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Requisicion>(entity =>
        {
            entity.HasKey(e => e.RequisicionId).HasName("PK__Requisic__BF9D09185E60020F");

            entity.HasIndex(e => e.CodigoRequisicion, "UQ__Requisic__5DC360DEFD3AF867").IsUnique();

            entity.Property(e => e.RequisicionId)
                .ValueGeneratedNever()
                .HasColumnName("RequisicionID");
            entity.Property(e => e.CodigoRequisicion).ValueGeneratedOnAdd();
            entity.Property(e => e.Comentario).HasMaxLength(255);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Solicitado).HasMaxLength(255);
        });

        modelBuilder.Entity<Salida>(entity =>
        {
            entity.HasKey(e => e.SalidaId).HasName("PK__Salida__DC997103BD1B4234");

            entity.HasIndex(e => e.Codigo, "UQ__Salida__06370DAC58658D84").IsUnique();

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
                .HasConstraintName("FK__Salida__BodegaID__6D0D32F4");

            entity.HasOne(d => d.Motivo).WithMany(p => p.Salida)
                .HasForeignKey(d => d.MotivoId)
                .HasConstraintName("FK__Salida__MotivoID__6B24EA82");

            entity.HasOne(d => d.Requisicion).WithMany(p => p.Salida)
                .HasForeignKey(d => d.RequisicionId)
                .HasConstraintName("FK__Salida__Requisic__6C190EBB");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.TipoId).HasName("PK__Tipo__97099E975234E437");

            entity.Property(e => e.TipoId)
                .ValueGeneratedNever()
                .HasColumnName("TipoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoPersona>(entity =>
        {
            entity.HasKey(e => e.TipoPersonaId).HasName("PK__TipoPers__485B782801CCA24C");

            entity.Property(e => e.TipoPersonaId)
                .ValueGeneratedNever()
                .HasColumnName("TipoPersonaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoProveedor>(entity =>
        {
            entity.HasKey(e => e.TipoProveedorId).HasName("PK__TipoProv__4F4779203298E7BE");

            entity.Property(e => e.TipoProveedorId)
                .ValueGeneratedNever()
                .HasColumnName("TipoProveedorID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE798C9748E43");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A1992DCBCD2").IsUnique();

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasColumnName("UsuarioID");
            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.Password).HasMaxLength(255);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__Usuario__Empresa__6E01572D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
