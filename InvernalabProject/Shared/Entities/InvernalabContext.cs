using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InvernalabProject.Shared.Entities;

public partial class InvernalabContext : DbContext
{
    public InvernalabContext()
    {
    }

    public InvernalabContext(DbContextOptions<InvernalabContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividads { get; set; }

    public virtual DbSet<Bloque> Bloques { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Etapa> Etapas { get; set; }

    public virtual DbSet<Funcion> Funcions { get; set; }

    public virtual DbSet<Insumo> Insumos { get; set; }

    public virtual DbSet<Intervalo> Intervalos { get; set; }

    public virtual DbSet<Maquinarium> Maquinaria { get; set; }

    public virtual DbSet<Nave> Naves { get; set; }

    public virtual DbSet<Proceso> Procesos { get; set; }

    public virtual DbSet<ProcesoActividad> ProcesoActividads { get; set; }

    public virtual DbSet<ProcesoActividadInsumo> ProcesoActividadInsumos { get; set; }

    public virtual DbSet<ProcesoActividadMaquinarium> ProcesoActividadMaquinaria { get; set; }

    public virtual DbSet<ProcesoActividadUsuario> ProcesoActividadUsuarios { get; set; }

    public virtual DbSet<ProcesoNave> ProcesoNaves { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ReporteSensor> ReporteSensors { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Sensor> Sensors { get; set; }

    public virtual DbSet<Terreno> Terrenos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actividad>(entity =>
        {
            entity.HasKey(e => e.IdActividad);

            entity.ToTable("actividad");

            entity.Property(e => e.IdActividad).HasColumnName("idActividad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.IdEtapa).HasColumnName("idEtapa");
            entity.Property(e => e.Imagen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdEtapaNavigation).WithMany(p => p.Actividads)
                .HasForeignKey(d => d.IdEtapa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_actividad_etapa");
        });

        modelBuilder.Entity<Bloque>(entity =>
        {
            entity.HasKey(e => e.IdBloque).HasName("PK_nave");

            entity.ToTable("bloque");

            entity.Property(e => e.IdBloque).HasColumnName("idBloque");
            entity.Property(e => e.Area)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("area");
            entity.Property(e => e.Codigo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.IdTerreno).HasColumnName("idTerreno");

            entity.HasOne(d => d.IdTerrenoNavigation).WithMany(p => p.Bloques)
                .HasForeignKey(d => d.IdTerreno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bloque_terreno");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.ToTable("categoria");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Caracteristicas)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("caracteristicas");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.IdEmpresa);

            entity.ToTable("empresa");

            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.Logo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("logo");
            entity.Property(e => e.Nit)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nit");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Usuario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("usuario");
        });

        modelBuilder.Entity<Etapa>(entity =>
        {
            entity.HasKey(e => e.IdEtapa);

            entity.ToTable("etapa");

            entity.Property(e => e.IdEtapa)
                .ValueGeneratedNever()
                .HasColumnName("idEtapa");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Funcion>(entity =>
        {
            entity.HasKey(e => e.IdFuncion);

            entity.ToTable("funcion");

            entity.Property(e => e.IdFuncion).HasColumnName("idFuncion");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Funcions)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_funcion_rol");
        });

        modelBuilder.Entity<Insumo>(entity =>
        {
            entity.HasKey(e => e.IdInsumo);

            entity.ToTable("insumo");

            entity.Property(e => e.IdInsumo).HasColumnName("idInsumo");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaCaducidad)
                .HasColumnType("date")
                .HasColumnName("fechaCaducidad");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.Imagen)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Medida).HasColumnName("medida");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Presentacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("presentacion");
        });

        modelBuilder.Entity<Intervalo>(entity =>
        {
            entity.HasKey(e => e.IdIntervalo);

            entity.ToTable("intervalo");

            entity.Property(e => e.IdIntervalo).HasColumnName("idIntervalo");
            entity.Property(e => e.Accion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("accion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.IdProceso).HasColumnName("idProceso");
            entity.Property(e => e.IdSensor).HasColumnName("idSensor");
            entity.Property(e => e.ValorMaximo).HasColumnName("valorMaximo");
            entity.Property(e => e.ValorMinimo).HasColumnName("valorMinimo");

            entity.HasOne(d => d.IdProcesoNavigation).WithMany(p => p.Intervalos)
                .HasForeignKey(d => d.IdProceso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_intervalo_proceso");

            entity.HasOne(d => d.IdSensorNavigation).WithMany(p => p.Intervalos)
                .HasForeignKey(d => d.IdSensor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_intervalo_sensor");
        });

        modelBuilder.Entity<Maquinarium>(entity =>
        {
            entity.HasKey(e => e.IdMaquinaria);

            entity.ToTable("maquinaria");

            entity.Property(e => e.IdMaquinaria).HasColumnName("idMaquinaria");
            entity.Property(e => e.Codigo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.NombreMaquinaria)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreMaquinaria");
        });

        modelBuilder.Entity<Nave>(entity =>
        {
            entity.HasKey(e => e.IdNave).HasName("PK_area");

            entity.ToTable("nave");

            entity.Property(e => e.IdNave).HasColumnName("idNave");
            entity.Property(e => e.Codigo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("codigo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.IdBloque).HasColumnName("idBloque");

            entity.HasOne(d => d.IdBloqueNavigation).WithMany(p => p.Naves)
                .HasForeignKey(d => d.IdBloque)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_nave_bloque");
        });

        modelBuilder.Entity<Proceso>(entity =>
        {
            entity.HasKey(e => e.IdProceso);

            entity.ToTable("proceso");

            entity.Property(e => e.IdProceso).HasColumnName("idProceso");
            entity.Property(e => e.Compartir).HasColumnName("compartir");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fechaInicio");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Procesos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_proceso_producto");
        });

        modelBuilder.Entity<ProcesoActividad>(entity =>
        {
            entity.HasKey(e => e.IdProcesoActividad);

            entity.ToTable("procesoActividad");

            entity.Property(e => e.IdProcesoActividad).HasColumnName("idProcesoActividad");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaEjecucion)
                .HasColumnType("date")
                .HasColumnName("fechaEjecucion");
            entity.Property(e => e.FechaFinal)
                .HasColumnType("date")
                .HasColumnName("fechaFinal");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("date")
                .HasColumnName("fechaInicio");
            entity.Property(e => e.IdActividad).HasColumnName("idActividad");
            entity.Property(e => e.IdProceso).HasColumnName("idProceso");

            entity.HasOne(d => d.IdActividadNavigation).WithMany(p => p.ProcesoActividads)
                .HasForeignKey(d => d.IdActividad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_procesoActividad_actividad");

            entity.HasOne(d => d.IdProcesoNavigation).WithMany(p => p.ProcesoActividads)
                .HasForeignKey(d => d.IdProceso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_procesoActividad_proceso");
        });

        modelBuilder.Entity<ProcesoActividadInsumo>(entity =>
        {
            entity.HasKey(e => e.IdProcesoInsumo);

            entity.ToTable("procesoActividadInsumo");

            entity.Property(e => e.IdProcesoInsumo).HasColumnName("idProcesoInsumo");
            entity.Property(e => e.CantidadAplicada).HasColumnName("cantidadAplicada");
            entity.Property(e => e.IdInsumo).HasColumnName("idInsumo");
            entity.Property(e => e.IdProcesoActividad).HasColumnName("idProcesoActividad");

            entity.HasOne(d => d.IdInsumoNavigation).WithMany(p => p.ProcesoActividadInsumos)
                .HasForeignKey(d => d.IdInsumo)
                .HasConstraintName("FK_procesoActividadInsumo_insumo");

            entity.HasOne(d => d.IdProcesoActividadNavigation).WithMany(p => p.ProcesoActividadInsumos)
                .HasForeignKey(d => d.IdProcesoActividad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_procesoActividadInsumo_procesoActividad");
        });

        modelBuilder.Entity<ProcesoActividadMaquinarium>(entity =>
        {
            entity.HasKey(e => e.IdProcesoActividadMaquinaria);

            entity.ToTable("procesoActividadMaquinaria");

            entity.Property(e => e.IdProcesoActividadMaquinaria).HasColumnName("idProcesoActividadMaquinaria");
            entity.Property(e => e.IdMaquinaria).HasColumnName("idMaquinaria");
            entity.Property(e => e.IdProcesoActividad).HasColumnName("idProcesoActividad");

            entity.HasOne(d => d.IdMaquinariaNavigation).WithMany(p => p.ProcesoActividadMaquinaria)
                .HasForeignKey(d => d.IdMaquinaria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_procesoActividadMaquinaria_maquinaria");

            entity.HasOne(d => d.IdProcesoActividadNavigation).WithMany(p => p.ProcesoActividadMaquinaria)
                .HasForeignKey(d => d.IdProcesoActividad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_procesoActividadMaquinaria_procesoActividad");
        });

        modelBuilder.Entity<ProcesoActividadUsuario>(entity =>
        {
            entity.HasKey(e => e.IdProcesoActividadUsuario);

            entity.ToTable("procesoActividadUsuario");

            entity.Property(e => e.IdProcesoActividadUsuario)
                .ValueGeneratedNever()
                .HasColumnName("idProcesoActividadUsuario");
            entity.Property(e => e.IdProcesoActividad).HasColumnName("idProcesoActividad");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdProcesoActividadNavigation).WithMany(p => p.ProcesoActividadUsuarios)
                .HasForeignKey(d => d.IdProcesoActividad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_procesoActividadUsuario_procesoActividad");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.ProcesoActividadUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_procesoActividadUsuario_usuario");
        });

        modelBuilder.Entity<ProcesoNave>(entity =>
        {
            entity.HasKey(e => e.IdProcesoNave);

            entity.ToTable("procesoNave");

            entity.Property(e => e.IdProcesoNave).HasColumnName("idProcesoNave");
            entity.Property(e => e.IdNave).HasColumnName("idNave");
            entity.Property(e => e.IdProceso).HasColumnName("idProceso");

            entity.HasOne(d => d.IdNaveNavigation).WithMany(p => p.ProcesoNaves)
                .HasForeignKey(d => d.IdNave)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_procesoNave_nave");

            entity.HasOne(d => d.IdProcesoNavigation).WithMany(p => p.ProcesoNaves)
                .HasForeignKey(d => d.IdProceso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_procesoNave_proceso");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.ToTable("producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Caracteristicas)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("caracteristicas");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_producto_categoria");
        });

        modelBuilder.Entity<ReporteSensor>(entity =>
        {
            entity.HasKey(e => e.IdReporteSensor);

            entity.ToTable("reporteSensor");

            entity.Property(e => e.IdReporteSensor).HasColumnName("idReporteSensor");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.IdSensor).HasColumnName("idSensor");
            entity.Property(e => e.ValorMaximoLectura).HasColumnName("valorMaximoLectura");
            entity.Property(e => e.ValorMinimoLectura).HasColumnName("valorMinimoLectura");

            entity.HasOne(d => d.IdSensorNavigation).WithMany(p => p.ReporteSensors)
                .HasForeignKey(d => d.IdSensor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_reporteSensor_sensor");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreRol");
        });

        modelBuilder.Entity<Sensor>(entity =>
        {
            entity.HasKey(e => e.IdSensor);

            entity.ToTable("sensor");

            entity.Property(e => e.IdSensor).HasColumnName("idSensor");
            entity.Property(e => e.TipoSensor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipoSensor");
            entity.Property(e => e.ValorMaximoFabricante).HasColumnName("valorMaximoFabricante");
            entity.Property(e => e.ValorMinimoFabricante).HasColumnName("valorMinimoFabricante");
        });

        modelBuilder.Entity<Terreno>(entity =>
        {
            entity.HasKey(e => e.IdTerreno);

            entity.ToTable("terreno");

            entity.Property(e => e.IdTerreno).HasColumnName("idTerreno");
            entity.Property(e => e.Area)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("area");
            entity.Property(e => e.CodigoTerreno)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Terrenos)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_terreno_empresa1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contraseña");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FechaInsert)
                .HasColumnType("date")
                .HasColumnName("fechaInsert");
            entity.Property(e => e.FechaUpdate)
                .HasColumnType("date")
                .HasColumnName("fechaUpdate");
            entity.Property(e => e.Foto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("foto");
            entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuario_empresa");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuario_rol");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
