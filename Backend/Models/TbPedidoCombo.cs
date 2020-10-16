using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tb_pedido_combo")]
    public partial class TbPedidoCombo
    {
        [Key]
        [Column("id_pedido_combo")]
        public int IdPedidoCombo { get; set; }
        [Column("id_pedido")]
        public int? IdPedido { get; set; }
        [Column("id_combo")]
        public int? IdCombo { get; set; }
        [Column("nr_qtd_combo")]
        public int? NrQtdCombo { get; set; }

        [ForeignKey(nameof(IdCombo))]
        [InverseProperty(nameof(TbCombo.TbPedidoCombo))]
        public virtual TbCombo IdComboNavigation { get; set; }
        [ForeignKey(nameof(IdPedido))]
        [InverseProperty(nameof(TbPedido.TbPedidoCombo))]
        public virtual TbPedido IdPedidoNavigation { get; set; }
    }
}
