using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsertsAPI.Models
{
    [Table("tb_ingresso")]
    public partial class TbIngresso
    {
        [Key]
        [Column("id_ingresso")]
        public int IdIngresso { get; set; }
        [Column("id_pedido")]
        public int? IdPedido { get; set; }
        [Column("id_sessao")]
        public int? IdSessao { get; set; }
        [Column("ds_fileira", TypeName = "varchar(1)")]
        public string DsFileira { get; set; }
        [Column("nr_poltrona")]
        public int? NrPoltrona { get; set; }
        [Column("bt_meia_entrada")]
        public bool? BtMeiaEntrada { get; set; }

        [ForeignKey(nameof(IdPedido))]
        [InverseProperty(nameof(TbPedido.TbIngresso))]
        public virtual TbPedido IdPedidoNavigation { get; set; }
        [ForeignKey(nameof(IdSessao))]
        [InverseProperty(nameof(TbSessao.TbIngresso))]
        public virtual TbSessao IdSessaoNavigation { get; set; }
    }
}
