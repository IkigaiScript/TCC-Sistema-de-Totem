using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tb_nota_fiscal")]
    public partial class TbNotaFiscal
    {
        [Key]
        [Column("id_nota_fisical")]
        public int IdNotaFisical { get; set; }
        [Column("id_pedido")]
        public int? IdPedido { get; set; }
        [Column("ds_email", TypeName = "varchar(255)")]
        public string DsEmail { get; set; }
        [Column("ds_cpf", TypeName = "varchar(255)")]
        public string DsCpf { get; set; }

        [ForeignKey(nameof(IdPedido))]
        [InverseProperty(nameof(TbPedido.TbNotaFiscal))]
        public virtual TbPedido IdPedidoNavigation { get; set; }
    }
}
