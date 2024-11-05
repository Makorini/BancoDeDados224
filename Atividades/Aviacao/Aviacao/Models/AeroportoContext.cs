using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Aviacao.Models;

public partial class AeroportoContext : DbContext
{
    public AeroportoContext()
    {
    }

    public AeroportoContext(DbContextOptions<AeroportoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aeronave> Aeronaves { get; set; }

    public virtual DbSet<Aeroporto> Aeroportos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Escala> Escalas { get; set; }

    public virtual DbSet<Horario> Horarios { get; set; }

    public virtual DbSet<TipoAeronave> TipoAeronaves { get; set; }

    public virtual DbSet<Voo> Voos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Aeroporto;User ID=;Password=;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aeronave>(entity =>
        {
            entity.HasKey(e => e.IdAeronave).HasName("PK_dbo.AERONAVE");

            entity.ToTable("AERONAVE");

            entity.Property(e => e.IdAeronave).HasColumnName("ID_AERONAVE");
            entity.Property(e => e.IdTipoAeronave).HasColumnName("ID_TIPO_AERONAVE");
            entity.Property(e => e.QtdPoltronas).HasColumnName("QTD_POLTRONAS");

            entity.HasOne(d => d.IdTipoAeronaveNavigation).WithMany(p => p.Aeronaves)
                .HasForeignKey(d => d.IdTipoAeronave)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_dbo.AERONAVE_dbo.TIPOAERONAVE_IDTIPOAERONAVE");
        });

        modelBuilder.Entity<Aeroporto>(entity =>
        {
            entity.HasKey(e => e.IdAeroporto).HasName("PK_dbo.AEROPORTO");

            entity.ToTable("AEROPORTO");

            entity.Property(e => e.IdAeroporto).HasColumnName("ID_AEROPORTO");
            entity.Property(e => e.Localizacao)
                .HasColumnType("ntext")
                .HasColumnName("LOCALIZACAO");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK_dbo.CLIENTE");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.Contato)
                .HasColumnType("ntext")
                .HasColumnName("CONTATO");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("datetime")
                .HasColumnName("DATA_NASCIMENTO");
            entity.Property(e => e.Genero)
                .HasColumnType("ntext")
                .HasColumnName("GENERO");
            entity.Property(e => e.Nome)
                .HasColumnType("ntext")
                .HasColumnName("NOME");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK_dbo.COMPRA");

            entity.ToTable("COMPRA");

            entity.Property(e => e.IdCompra).HasColumnName("ID_COMPRA");
            entity.Property(e => e.IdCliente).HasColumnName("ID_CLIENTE");
            entity.Property(e => e.IdHorario).HasColumnName("ID_HORARIO");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_dbo.COMPRA_dbo.CLIENTE_IDCLIENTE");

            entity.HasOne(d => d.IdHorarioNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.IdHorario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_dbo.COMPRA_dbo.HORARIO_IDHORARIO");
        });

        modelBuilder.Entity<Escala>(entity =>
        {
            entity.HasKey(e => e.IdEscala).HasName("PK_dbo.ESCALA");

            entity.ToTable("ESCALA");

            entity.Property(e => e.IdEscala).HasColumnName("ID_ESCALA");
            entity.Property(e => e.HorarioSaida)
                .HasColumnType("datetime")
                .HasColumnName("HORARIO_SAIDA");
            entity.Property(e => e.IdAeroportoSaida).HasColumnName("ID_AEROPORTO_SAIDA");
            entity.Property(e => e.IdVoo).HasColumnName("ID_VOO");

            entity.HasOne(d => d.IdAeroportoSaidaNavigation).WithMany(p => p.Escalas)
                .HasForeignKey(d => d.IdAeroportoSaida)
                .HasConstraintName("FK_dbo.ESCALA_dbo.AEROPORTO_IDAEROPORTO");

            entity.HasOne(d => d.IdVooNavigation).WithMany(p => p.Escalas)
                .HasForeignKey(d => d.IdVoo)
                .HasConstraintName("FK_dbo.ESCALA_dbo.VOO_IDVOO");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario).HasName("PK_dbo.HORARIO");

            entity.ToTable("HORARIO");

            entity.Property(e => e.IdHorario).HasColumnName("ID_HORARIO");
            entity.Property(e => e.Disponibilidade)
                .HasDefaultValue(1)
                .HasColumnName("DISPONIBILIDADE");
            entity.Property(e => e.IdVoo).HasColumnName("ID_VOO");
            entity.Property(e => e.LadoPoltrona)
                .HasColumnType("ntext")
                .HasColumnName("LADO_POLTRONA");
            entity.Property(e => e.LocalizacaoPoltrona)
                .HasColumnType("ntext")
                .HasColumnName("LOCALIZACAO_POLTRONA");

            entity.HasOne(d => d.IdVooNavigation).WithMany(p => p.Horarios)
                .HasForeignKey(d => d.IdVoo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_dbo.HORARIO_dbo.VOO_IDVOO");
        });

        modelBuilder.Entity<TipoAeronave>(entity =>
        {
            entity.HasKey(e => e.IdTipoAeronave).HasName("PK_dbo.TIPO_AERONAVE");

            entity.ToTable("TIPO_AERONAVE");

            entity.Property(e => e.IdTipoAeronave).HasColumnName("ID_TIPO_AERONAVE");
            entity.Property(e => e.Descricao)
                .HasColumnType("ntext")
                .HasColumnName("DESCRICAO");
        });

        modelBuilder.Entity<Voo>(entity =>
        {
            entity.HasKey(e => e.IdVoo).HasName("PK_dbo.VOO");

            entity.ToTable("VOO");

            entity.Property(e => e.IdVoo).HasColumnName("ID_VOO");
            entity.Property(e => e.HorarioDestino)
                .HasColumnType("datetime")
                .HasColumnName("HORARIO_DESTINO");
            entity.Property(e => e.HorarioSaida)
                .HasColumnType("datetime")
                .HasColumnName("HORARIO_SAIDA");
            entity.Property(e => e.IdAeronave).HasColumnName("ID_AERONAVE");
            entity.Property(e => e.IdAeroportoDestino).HasColumnName("ID_AEROPORTO_DESTINO");
            entity.Property(e => e.IdAeroportoSaida).HasColumnName("ID_AEROPORTO_SAIDA");

            entity.HasOne(d => d.IdAeronaveNavigation).WithMany(p => p.Voos)
                .HasForeignKey(d => d.IdAeronave)
                .HasConstraintName("FK_dbo.VOO_dbo.AERONAVE_IDAERONAVE");

            entity.HasOne(d => d.IdAeroportoDestinoNavigation).WithMany(p => p.VooIdAeroportoDestinoNavigations)
                .HasForeignKey(d => d.IdAeroportoDestino)
                .HasConstraintName("FK_dbo.VOO_dbo.AEROPORTODESTINO_IDAEROPORTO");

            entity.HasOne(d => d.IdAeroportoSaidaNavigation).WithMany(p => p.VooIdAeroportoSaidaNavigations)
                .HasForeignKey(d => d.IdAeroportoSaida)
                .HasConstraintName("FK_dbo.VOO_dbo.AEROPORTOSAIDA_IDAEROPORTO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
