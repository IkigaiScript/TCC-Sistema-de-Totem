using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsertsAPI.Models
{
    [Table("tb_pedido")]
    public partial class TbPedido
    {
        public TbPedido()
        {
            TbCartao = new HashSet<TbCartao>();
            TbIngresso = new HashSet<TbIngresso>();
            TbNotaFiscal = new HashSet<TbNotaFiscal>();
            TbPedidoCombo = new HashSet<TbPedidoCombo>();
            TbPedidoSnackBar = new HashSet<TbPedidoSnackBar>();
        }

        [Key]
        [Column("id_pedido")]
        public int IdPedido { get; set; }
        [Column("id_cupom_desconto")]
        public int? IdCupomDesconto { get; set; }
        [Column("id_login")]
        public int? IdLogin { get; set; }
        [Column("nm_titular", TypeName = "varchar(100)")]
        public string NmTitular { get; set; }
        [Column("ds_forma_pagamento", TypeName = "varchar(255)")]
        public string DsFormaPagamento { get; set; }
        [Column("ds_status", TypeName = "varchar(255)")]
        public string DsStatus { get; set; }
        [Column("vl_total", TypeName = "decimal(10,2)")]
        public decimal? VlTotal { get; set; }
        [Column("vl_troco", TypeName = "decimal(10,2)")]
        public decimal? VlTroco { get; set; }

        [ForeignKey(nameof(IdCupomDesconto))]
        [InverseProperty(nameof(TbCupomDesconto.TbPedido))]
        public virtual TbCupomDesconto IdCupomDescontoNavigation { get; set; }
        [ForeignKey(nameof(IdLogin))]
        [InverseProperty(nameof(TbLogin.TbPedido))]
        public virtual TbLogin IdLoginNavigation { get; set; }
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<TbCartao> TbCartao { get; set; }
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<TbIngresso> TbIngresso { get; set; }
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<TbNotaFiscal> TbNotaFiscal { get; set; }
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<TbPedidoCombo> TbPedidoCombo { get; set; }
        [InverseProperty("IdPedidoNavigation")]
        public virtual ICollection<TbPedidoSnackBar> TbPedidoSnackBar { get; set; }
    }
}
