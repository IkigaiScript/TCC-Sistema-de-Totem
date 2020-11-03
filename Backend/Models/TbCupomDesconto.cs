using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tb_cupom_desconto")]
    public partial class TbCupomDesconto
    {
        public TbCupomDesconto()
        {
            TbPedido = new HashSet<TbPedido>();
        }

        [Key]
        [Column("id_cupom_desconto")]
        public int IdCupomDesconto { get; set; }
        [Required]
        [Column("nm_cupom", TypeName = "varchar(100)")]
        public string NmCupom { get; set; }
        [Required]
        [Column("ds_codigo", TypeName = "varchar(100)")]
        public string DsCodigo { get; set; }
        [Column("vl_desconto", TypeName = "decimal(10,2)")]
        public decimal VlDesconto { get; set; }
        [Column("vl_min_gasto", TypeName = "decimal(10,2)")]
        public decimal VlMinGasto { get; set; }

        [InverseProperty("IdCupomDescontoNavigation")]
        public virtual ICollection<TbPedido> TbPedido { get; set; }
    }
}
