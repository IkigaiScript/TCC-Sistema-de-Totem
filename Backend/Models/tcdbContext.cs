using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Backend.Models
{
    public partial class tcdbContext : DbContext
    {
        public tcdbContext()
        {
        }

        public tcdbContext(DbContextOptions<tcdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAtor> TbAtor { get; set; }
        public virtual DbSet<TbCartao> TbCartao { get; set; }
        public virtual DbSet<TbCliente> TbCliente { get; set; }
        public virtual DbSet<TbCombo> TbCombo { get; set; }
        public virtual DbSet<TbCupomDesconto> TbCupomDesconto { get; set; }
        public virtual DbSet<TbDiretor> TbDiretor { get; set; }
        public virtual DbSet<TbFilme> TbFilme { get; set; }
        public virtual DbSet<TbIngresso> TbIngresso { get; set; }
        public virtual DbSet<TbLogin> TbLogin { get; set; }
        public virtual DbSet<TbNotaFiscal> TbNotaFiscal { get; set; }
        public virtual DbSet<TbPedido> TbPedido { get; set; }
        public virtual DbSet<TbPedidoCombo> TbPedidoCombo { get; set; }
        public virtual DbSet<TbPedidoSnackBar> TbPedidoSnackBar { get; set; }
        public virtual DbSet<TbSessao> TbSessao { get; set; }
        public virtual DbSet<TbSnackBar> TbSnackBar { get; set; }
        public virtual DbSet<TbTrailer> TbTrailer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;userid=adm;password=12345678;database=tcdb", x => x.ServerVersion("8.0.21-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAtor>(entity =>
            {
                entity.HasKey(e => e.IdAtor)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdFilme)
                    .HasName("id_filme");

                entity.Property(e => e.NmAtor)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.TbAtor)
                    .HasForeignKey(d => d.IdFilme)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_ator_ibfk_1");
            });

            modelBuilder.Entity<TbCartao>(entity =>
            {
                entity.HasKey(e => e.IdCartao)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdPedido)
                    .HasName("id_pedido");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.TbCartao)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_cartao_ibfk_1");
            });

            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdLogin)
                    .HasName("id_login");

                entity.Property(e => e.DsCelular)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsCep)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsCpf)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsRg)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmCliente)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.TbCliente)
                    .HasForeignKey(d => d.IdLogin)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_cliente_ibfk_1");
            });

            modelBuilder.Entity<TbCombo>(entity =>
            {
                entity.HasKey(e => e.IdCombo)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsFirstItem)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsImagem)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsSecondaryItem)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsThirdItem)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmCombo)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbCupomDesconto>(entity =>
            {
                entity.HasKey(e => e.IdCupomDesconto)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsCodigo)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmCupom)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbDiretor>(entity =>
            {
                entity.HasKey(e => e.IdDiretor)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdFilme)
                    .HasName("id_filme");

                entity.Property(e => e.NmDiretor)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.TbDiretor)
                    .HasForeignKey(d => d.IdFilme)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_diretor_ibfk_1");
            });

            modelBuilder.Entity<TbFilme>(entity =>
            {
                entity.HasKey(e => e.IdFilme)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.NmFilme)
                    .HasName("nm_filme")
                    .IsUnique();

                entity.Property(e => e.DsGenero)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsImagem)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsSinopse)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmFilme)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbIngresso>(entity =>
            {
                entity.HasKey(e => e.IdIngresso)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdPedido)
                    .HasName("id_pedido");

                entity.HasIndex(e => e.IdSessao)
                    .HasName("id_sessao");

                entity.Property(e => e.DsFileira)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.TbIngresso)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_ingresso_ibfk_1");

                entity.HasOne(d => d.IdSessaoNavigation)
                    .WithMany(p => p.TbIngresso)
                    .HasForeignKey(d => d.IdSessao)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_ingresso_ibfk_2");
            });

            modelBuilder.Entity<TbLogin>(entity =>
            {
                entity.HasKey(e => e.IdLogin)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsEmail)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsSenha)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbNotaFiscal>(entity =>
            {
                entity.HasKey(e => e.IdNotaFisical)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdPedido)
                    .HasName("id_pedido");

                entity.Property(e => e.DsCpf)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsEmail)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.TbNotaFiscal)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_nota_fiscal_ibfk_1");
            });

            modelBuilder.Entity<TbPedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCupomDesconto)
                    .HasName("id_cupom_desconto");

                entity.HasIndex(e => e.IdLogin)
                    .HasName("id_login");

                entity.Property(e => e.DsFormaPagamento)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsStatus)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmTitular)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdCupomDescontoNavigation)
                    .WithMany(p => p.TbPedido)
                    .HasForeignKey(d => d.IdCupomDesconto)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_pedido_ibfk_1");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.TbPedido)
                    .HasForeignKey(d => d.IdLogin)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_pedido_ibfk_2");
            });

            modelBuilder.Entity<TbPedidoCombo>(entity =>
            {
                entity.HasKey(e => e.IdPedidoCombo)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCombo)
                    .HasName("id_combo");

                entity.HasIndex(e => e.IdPedido)
                    .HasName("id_pedido");

                entity.HasOne(d => d.IdComboNavigation)
                    .WithMany(p => p.TbPedidoCombo)
                    .HasForeignKey(d => d.IdCombo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_pedido_combo_ibfk_2");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.TbPedidoCombo)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_pedido_combo_ibfk_1");
            });

            modelBuilder.Entity<TbPedidoSnackBar>(entity =>
            {
                entity.HasKey(e => e.IdPedidoSnackBar)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdPedido)
                    .HasName("id_pedido");

                entity.HasIndex(e => e.IdSnackBar)
                    .HasName("id_snack_bar");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.TbPedidoSnackBar)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_pedido_snack_bar_ibfk_2");

                entity.HasOne(d => d.IdSnackBarNavigation)
                    .WithMany(p => p.TbPedidoSnackBar)
                    .HasForeignKey(d => d.IdSnackBar)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_pedido_snack_bar_ibfk_1");
            });

            modelBuilder.Entity<TbSessao>(entity =>
            {
                entity.HasKey(e => e.IdSessao)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdFilme)
                    .HasName("id_filme");

                entity.Property(e => e.DsTipoSala)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.TbSessao)
                    .HasForeignKey(d => d.IdFilme)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_sessao_ibfk_1");
            });

            modelBuilder.Entity<TbSnackBar>(entity =>
            {
                entity.HasKey(e => e.IdSnackBar)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsImagem)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsMarca)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsPeso)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsSabor)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsTipoProduto)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmProduto)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbTrailer>(entity =>
            {
                entity.HasKey(e => e.IdTrailer)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdFilme)
                    .HasName("id_filme");

                entity.Property(e => e.NmTrailer)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.TbTrailer)
                    .HasForeignKey(d => d.IdFilme)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_trailer_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
