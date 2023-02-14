using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

    public virtual DbSet<Departamento> Departamento { get; set; }

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

    public virtual DbSet<TipoIngreso> TipoIngreso { get; set; }

    public virtual DbSet<TipoPersona> TipoPersona { get; set; }

    public virtual DbSet<TipoProveedor> TipoProveedor { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=laloba;Initial Catalog=DbInventario;Integrated Security=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bodega>(entity =>
        {
            entity.HasKey(e => e.BodegaId).HasName("PK__Bodega__37A29A75C22C2F8B");

            entity.Property(e => e.BodegaId)
                .ValueGeneratedNever()
                .HasColumnName("BodegaID");
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.EstadoId).HasColumnName("EstadoID");
            entity.Property(e => e.ProvinciaId).HasColumnName("ProvinciaID");

            entity.HasOne(d => d.Empresa).WithMany(p => p.Bodega)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__Bodega__EmpresaI__797309D9");

            entity.HasOne(d => d.Estado).WithMany(p => p.Bodega)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Bodega__EstadoID__7B5B524B");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Bodega)
                .HasForeignKey(d => d.ProvinciaId)
                .HasConstraintName("FK__Bodega__Provinci__7A672E12");
        });

        modelBuilder.Entity<Color>(entity =>
        {
            entity.HasKey(e => e.ColorId).HasName("PK__Color__8DA7676D19F90DE5");

            entity.Property(e => e.ColorId)
                .ValueGeneratedNever()
                .HasColumnName("ColorID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Producto).WithMany(p => p.Color)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Color__ProductoI__0F624AF8");
        });

        modelBuilder.Entity<CondicionPago>(entity =>
        {
            entity.HasKey(e => e.CondicionPagoId).HasName("PK__Condicio__586DA44F7094ABCD");

            entity.Property(e => e.CondicionPagoId)
                .ValueGeneratedNever()
                .HasColumnName("CondicionPagoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.DepartamentoId).HasName("PK__Departam__66BB0E1EC344BCCC");

            entity.Property(e => e.DepartamentoId)
                .ValueGeneratedNever()
                .HasColumnName("DepartamentoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.EmpresaId).HasName("PK__Empresa__7B9F213642F6628C");

            entity.HasIndex(e => e.Correo, "UQ__Empresa__60695A19A2AA3C04").IsUnique();

            entity.Property(e => e.EmpresaId)
                .ValueGeneratedNever()
                .HasColumnName("EmpresaID");
            entity.Property(e => e.Correo).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK__Estado__FEF86B607D323F3A");

            entity.Property(e => e.EstadoId)
                .ValueGeneratedNever()
                .HasColumnName("EstadoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Existencia>(entity =>
        {
            entity.HasKey(e => e.ExistenciaId).HasName("PK__Existenc__A23A887E7AC474DB");

            entity.Property(e => e.ExistenciaId)
                .ValueGeneratedNever()
                .HasColumnName("ExistenciaID");
            entity.Property(e => e.BodegaId).HasColumnName("BodegaID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Bodega).WithMany(p => p.Existencia)
                .HasForeignKey(d => d.BodegaId)
                .HasConstraintName("FK__Existenci__Bodeg__09A971A2");

            entity.HasOne(d => d.Producto).WithMany(p => p.Existencia)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Existenci__Produ__08B54D69");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.GrupoId).HasName("PK__Grupo__556BF060A278A032");

            entity.Property(e => e.GrupoId)
                .ValueGeneratedNever()
                .HasColumnName("GrupoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.HasKey(e => e.IngresoId).HasName("PK__Ingreso__DBF090BA1DFD6C10");

            entity.HasIndex(e => e.CodigoIngreso, "UQ__Ingreso__31F1175453DC67C9").IsUnique();

            entity.Property(e => e.IngresoId)
                .ValueGeneratedNever()
                .HasColumnName("IngresoID");
            entity.Property(e => e.BodegaId).HasColumnName("BodegaID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MotivoId).HasColumnName("MotivoID");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.TipoIngresoId).HasColumnName("TipoIngresoID");

            entity.HasOne(d => d.Bodega).WithMany(p => p.Ingreso)
                .HasForeignKey(d => d.BodegaId)
                .HasConstraintName("FK__Ingreso__BodegaI__00200768");

            entity.HasOne(d => d.Motivo).WithMany(p => p.Ingreso)
                .HasForeignKey(d => d.MotivoId)
                .HasConstraintName("FK__Ingreso__MotivoI__7F2BE32F");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Ingreso)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK__Ingreso__Proveed__7E37BEF6");

            entity.HasOne(d => d.TipoIngreso).WithMany(p => p.Ingreso)
                .HasForeignKey(d => d.TipoIngresoId)
                .HasConstraintName("FK__Ingreso__TipoIng__01142BA1");
        });

        modelBuilder.Entity<IngresoDetalle>(entity =>
        {
            entity.HasKey(e => e.IngresoDetalleId).HasName("PK__IngresoD__A917DA7279B9D3CD");

            entity.Property(e => e.IngresoDetalleId)
                .ValueGeneratedNever()
                .HasColumnName("IngresoDetalleID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.IngresoId).HasColumnName("IngresoID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Ingreso).WithMany(p => p.IngresoDetalle)
                .HasForeignKey(d => d.IngresoId)
                .HasConstraintName("FK__IngresoDe__Ingre__02FC7413");

            entity.HasOne(d => d.Producto).WithMany(p => p.IngresoDetalle)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__IngresoDe__Produ__02084FDA");
        });

        modelBuilder.Entity<Linea>(entity =>
        {
            entity.HasKey(e => e.LineaId).HasName("PK__Linea__78106D11CF7BD561");

            entity.Property(e => e.LineaId)
                .ValueGeneratedNever()
                .HasColumnName("LineaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<LineaCompra>(entity =>
        {
            entity.HasKey(e => e.LineaCompraId).HasName("PK__LineaCom__527F98BC12F685F1");

            entity.Property(e => e.LineaCompraId)
                .ValueGeneratedNever()
                .HasColumnName("LineaCompraID");
            entity.Property(e => e.DepartamentoId).HasColumnName("DepartamentoID");
            entity.Property(e => e.OrdenCompraId).HasColumnName("OrdenCompraID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Departamento).WithMany(p => p.LineaCompra)
                .HasForeignKey(d => d.DepartamentoId)
                .HasConstraintName("FK__LineaComp__Depar__0C85DE4D");

            entity.HasOne(d => d.OrdenCompra).WithMany(p => p.LineaCompra)
                .HasForeignKey(d => d.OrdenCompraId)
                .HasConstraintName("FK__LineaComp__Orden__0A9D95DB");

            entity.HasOne(d => d.Producto).WithMany(p => p.LineaCompra)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__LineaComp__Produ__0B91BA14");
        });

        modelBuilder.Entity<LineaSalida>(entity =>
        {
            entity.HasKey(e => e.LineaSalidaId).HasName("PK__LineaSal__DE2C0D98EBA7DE20");

            entity.Property(e => e.LineaSalidaId)
                .ValueGeneratedNever()
                .HasColumnName("LineaSalidaID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.SalidaId).HasColumnName("SalidaID");

            entity.HasOne(d => d.Producto).WithMany(p => p.LineaSalida)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__LineaSali__Produ__0E6E26BF");

            entity.HasOne(d => d.Salida).WithMany(p => p.LineaSalida)
                .HasForeignKey(d => d.SalidaId)
                .HasConstraintName("FK__LineaSali__Salid__0D7A0286");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("PK__Marca__D5B1CDEB973033D4");

            entity.Property(e => e.MarcaId)
                .ValueGeneratedNever()
                .HasColumnName("MarcaID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Producto).WithMany(p => p.Marca)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Marca__ProductoI__10566F31");
        });

        modelBuilder.Entity<Medida>(entity =>
        {
            entity.HasKey(e => e.MedidaId).HasName("PK__Medida__5F7A0CE29A261706");

            entity.Property(e => e.MedidaId)
                .ValueGeneratedNever()
                .HasColumnName("MedidaID");
            entity.Property(e => e.Dimension).HasMaxLength(255);
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Producto).WithMany(p => p.Medida)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Medida__Producto__114A936A");
        });

        modelBuilder.Entity<Motivo>(entity =>
        {
            entity.HasKey(e => e.MotivoId).HasName("PK__Motivo__AE78D2577DE0B79B");

            entity.Property(e => e.MotivoId)
                .ValueGeneratedNever()
                .HasColumnName("MotivoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<OrdenCompra>(entity =>
        {
            entity.HasKey(e => e.OrdenCompraId).HasName("PK__OrdenCom__0B556E16145E4D94");

            entity.Property(e => e.OrdenCompraId)
                .ValueGeneratedNever()
                .HasColumnName("OrdenCompraID");
            entity.Property(e => e.CondicionPagoId).HasColumnName("CondicionPagoID");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Observacion).HasColumnType("text");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.Referencia).HasMaxLength(255);

            entity.HasOne(d => d.CondicionPago).WithMany(p => p.OrdenCompra)
                .HasForeignKey(d => d.CondicionPagoId)
                .HasConstraintName("FK__OrdenComp__Condi__7D439ABD");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.OrdenCompra)
                .HasForeignKey(d => d.ProveedorId)
                .HasConstraintName("FK__OrdenComp__Prove__7C4F7684");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__A430AE836CD90E45");

            entity.Property(e => e.ProductoId)
                .ValueGeneratedNever()
                .HasColumnName("ProductoID");
            entity.Property(e => e.Activo).HasDefaultValueSql("((0))");
            entity.Property(e => e.Comentario).HasColumnType("text");
            entity.Property(e => e.FechaCaducidad).HasColumnType("datetime");
            entity.Property(e => e.GrupoId).HasColumnName("GrupoID");
            entity.Property(e => e.Iva)
                .HasDefaultValueSql("((0))")
                .HasColumnName("IVA");
            entity.Property(e => e.LineaId).HasColumnName("LineaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
            entity.Property(e => e.Perecible).HasDefaultValueSql("((0))");
            entity.Property(e => e.TipoId).HasColumnName("TipoID");

            entity.HasOne(d => d.Grupo).WithMany(p => p.Producto)
                .HasForeignKey(d => d.GrupoId)
                .HasConstraintName("FK__Producto__GrupoI__73BA3083");

            entity.HasOne(d => d.Linea).WithMany(p => p.Producto)
                .HasForeignKey(d => d.LineaId)
                .HasConstraintName("FK__Producto__LineaI__71D1E811");

            entity.HasOne(d => d.Tipo).WithMany(p => p.Producto)
                .HasForeignKey(d => d.TipoId)
                .HasConstraintName("FK__Producto__TipoID__72C60C4A");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PK__Proveedo__61266BB9CD1FB304");

            entity.HasIndex(e => e.Codigo, "UQ__Proveedo__06370DACA9F3E0E6").IsUnique();

            entity.Property(e => e.ProveedorId)
                .ValueGeneratedNever()
                .HasColumnName("ProveedorID");
            entity.Property(e => e.Contacto).HasMaxLength(255);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
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
                .HasConstraintName("FK__Proveedor__Empre__74AE54BC");

            entity.HasOne(d => d.Estado).WithMany(p => p.Proveedor)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK__Proveedor__Estad__778AC167");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Proveedor)
                .HasForeignKey(d => d.ProvinciaId)
                .HasConstraintName("FK__Proveedor__Provi__76969D2E");

            entity.HasOne(d => d.TipoPersonaNavigation).WithMany(p => p.Proveedor)
                .HasForeignKey(d => d.TipoPersona)
                .HasConstraintName("FK__Proveedor__TipoP__787EE5A0");

            entity.HasOne(d => d.TipoProveedor).WithMany(p => p.Proveedor)
                .HasForeignKey(d => d.TipoProveedorId)
                .HasConstraintName("FK__Proveedor__TipoP__75A278F5");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.ProvinciaId).HasName("PK__Provinci__F7CBC757CBBBB48B");

            entity.Property(e => e.ProvinciaId)
                .ValueGeneratedNever()
                .HasColumnName("ProvinciaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Requisicion>(entity =>
        {
            entity.HasKey(e => e.RequisicionId).HasName("PK__Requisic__BF9D09183FFFB00D");

            entity.HasIndex(e => e.CodigoRequisicion, "UQ__Requisic__5DC360DE04833723").IsUnique();

            entity.Property(e => e.RequisicionId)
                .ValueGeneratedNever()
                .HasColumnName("RequisicionID");
            entity.Property(e => e.CodigoRequisicion).HasMaxLength(255);
            entity.Property(e => e.Comentario).HasMaxLength(255);
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.OrdenCompraId).HasColumnName("OrdenCompraID");

            entity.HasOne(d => d.OrdenCompra).WithMany(p => p.Requisicion)
                .HasForeignKey(d => d.OrdenCompraId)
                .HasConstraintName("FK__Requisici__Orden__06CD04F7");
        });

        modelBuilder.Entity<Salida>(entity =>
        {
            entity.HasKey(e => e.SalidaId).HasName("PK__Salida__DC997103D12D855C");

            entity.HasIndex(e => e.Codigo, "UQ__Salida__06370DACD8A52C58").IsUnique();

            entity.Property(e => e.SalidaId)
                .ValueGeneratedNever()
                .HasColumnName("SalidaID");
            entity.Property(e => e.BodegaId).HasColumnName("BodegaID");
            entity.Property(e => e.Codigo).HasMaxLength(255);
            entity.Property(e => e.Comentario).HasColumnType("text");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.MotivoId).HasColumnName("MotivoID");
            entity.Property(e => e.RequisicionId).HasColumnName("RequisicionID");

            entity.HasOne(d => d.Bodega).WithMany(p => p.Salida)
                .HasForeignKey(d => d.BodegaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Salida__BodegaID__05D8E0BE");

            entity.HasOne(d => d.Motivo).WithMany(p => p.Salida)
                .HasForeignKey(d => d.MotivoId)
                .HasConstraintName("FK__Salida__MotivoID__03F0984C");

            entity.HasOne(d => d.Requisicion).WithMany(p => p.Salida)
                .HasForeignKey(d => d.RequisicionId)
                .HasConstraintName("FK__Salida__Requisic__04E4BC85");
        });

        modelBuilder.Entity<Tipo>(entity =>
        {
            entity.HasKey(e => e.TipoId).HasName("PK__Tipo__97099E9720D06289");

            entity.Property(e => e.TipoId)
                .ValueGeneratedNever()
                .HasColumnName("TipoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoIngreso>(entity =>
        {
            entity.HasKey(e => e.TipoIngresoId).HasName("PK__TipoIngr__B30C779E6DF80BCA");

            entity.Property(e => e.TipoIngresoId)
                .ValueGeneratedNever()
                .HasColumnName("TipoIngresoID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoPersona>(entity =>
        {
            entity.HasKey(e => e.TipoPersonaId).HasName("PK__TipoPers__485B7828C3FBB000");

            entity.Property(e => e.TipoPersonaId)
                .ValueGeneratedNever()
                .HasColumnName("TipoPersonaID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<TipoProveedor>(entity =>
        {
            entity.HasKey(e => e.TipoProveedorId).HasName("PK__TipoProv__4F47792070DAC098");

            entity.Property(e => e.TipoProveedorId)
                .ValueGeneratedNever()
                .HasColumnName("TipoProveedorID");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuario__2B3DE798B2376750");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A19AE0F1F55").IsUnique();

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedNever()
                .HasColumnName("UsuarioID");
            entity.Property(e => e.Correo).HasMaxLength(255);
            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.Password).HasMaxLength(255);

            entity.HasOne(d => d.Empresa).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.EmpresaId)
                .HasConstraintName("FK__Usuario__Empresa__07C12930");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
