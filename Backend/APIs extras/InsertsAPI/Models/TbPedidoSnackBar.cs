using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsertsAPI.Models
{
    [Table("tb_pedido_snack_bar")]
    public partial class TbPedidoSnackBar
    {
        [Key]
        [Column("id_pedido_snack_bar")]
        public int IdPedidoSnackBar { get; set; }
        [Column("id_pedido")]
        public int? IdPedido { get; set; }
        [Column("id_snack_bar")]
        public int? IdSnackBar { get; set; }
        [Column("nr_qtd_snack_bar")]
        public int? NrQtdSnackBar { get; set; }

        [ForeignKey(nameof(IdPedido))]
        [InverseProperty(nameof(TbPedido.TbPedidoSnackBar))]
        public virtual TbPedido IdPedidoNavigation { get; set; }
        [ForeignKey(nameof(IdSnackBar))]
        [InverseProperty(nameof(TbSnackBar.TbPedidoSnackBar))]
        public virtual TbSnackBar IdSnackBarNavigation { get; set; }
    }
}
