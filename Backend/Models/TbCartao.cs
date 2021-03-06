﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tb_cartao")]
    public partial class TbCartao
    {
        [Key]
        [Column("id_cartao")]
        public int IdCartao { get; set; }
        [Column("id_pedido")]
        public int IdPedido { get; set; }
        [Required]
        [Column("ds_cartao", TypeName = "varchar(100)")]
        public string DsCartao { get; set; }
        [Column("vl_gasto", TypeName = "decimal(10,2)")]
        public decimal VlGasto { get; set; }

        [ForeignKey(nameof(IdPedido))]
        [InverseProperty(nameof(TbPedido.TbCartao))]
        public virtual TbPedido IdPedidoNavigation { get; set; }
    }
}
