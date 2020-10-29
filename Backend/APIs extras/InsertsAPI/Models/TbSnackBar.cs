using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsertsAPI.Models
{
    [Table("tb_snack_bar")]
    public partial class TbSnackBar
    {
        public TbSnackBar()
        {
            TbPedidoSnackBar = new HashSet<TbPedidoSnackBar>();
        }

        [Key]
        [Column("id_snack_bar")]
        public int IdSnackBar { get; set; }
        [Column("nm_produto", TypeName = "varchar(100)")]
        public string NmProduto { get; set; }
        [Column("ds_tipo_produto", TypeName = "varchar(255)")]
        public string DsTipoProduto { get; set; }
        [Column("ds_marca", TypeName = "varchar(255)")]
        public string DsMarca { get; set; }
        [Column("ds_sabor", TypeName = "varchar(255)")]
        public string DsSabor { get; set; }
        [Column("ds_peso", TypeName = "varchar(255)")]
        public string DsPeso { get; set; }
        [Column("ds_imagem", TypeName = "varchar(255)")]
        public string DsImagem { get; set; }
        [Column("nr_qtd_estoque")]
        public int? NrQtdEstoque { get; set; }
        [Column("vl_preco", TypeName = "decimal(10,2)")]
        public decimal? VlPreco { get; set; }

        [InverseProperty("IdSnackBarNavigation")]
        public virtual ICollection<TbPedidoSnackBar> TbPedidoSnackBar { get; set; }
    }
}
