using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsertsAPI.Models
{
    [Table("tb_combo")]
    public partial class TbCombo
    {
        public TbCombo()
        {
            TbPedidoCombo = new HashSet<TbPedidoCombo>();
        }

        [Key]
        [Column("id_combo")]
        public int IdCombo { get; set; }
        [Column("nm_combo", TypeName = "varchar(100)")]
        public string NmCombo { get; set; }
        [Column("ds_first_item", TypeName = "varchar(255)")]
        public string DsFirstItem { get; set; }
        [Column("ds_secondary_item", TypeName = "varchar(255)")]
        public string DsSecondaryItem { get; set; }
        [Column("ds_third_item", TypeName = "varchar(255)")]
        public string DsThirdItem { get; set; }
        [Column("vl_preco", TypeName = "decimal(10,2)")]
        public decimal? VlPreco { get; set; }
        [Column("ds_imagem", TypeName = "varchar(255)")]
        public string DsImagem { get; set; }

        [InverseProperty("IdComboNavigation")]
        public virtual ICollection<TbPedidoCombo> TbPedidoCombo { get; set; }
    }
}
