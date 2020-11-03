using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tb_cliente")]
    public partial class TbCliente
    {
        [Key]
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        [Column("id_login")]
        public int IdLogin { get; set; }
        [Required]
        [Column("nm_cliente", TypeName = "varchar(100)")]
        public string NmCliente { get; set; }
        [Required]
        [Column("ds_cpf", TypeName = "varchar(14)")]
        public string DsCpf { get; set; }
        [Required]
        [Column("ds_cep", TypeName = "varchar(9)")]
        public string DsCep { get; set; }
        [Required]
        [Column("ds_rg", TypeName = "varchar(12)")]
        public string DsRg { get; set; }
        [Required]
        [Column("ds_celular", TypeName = "varchar(14)")]
        public string DsCelular { get; set; }
        [Column("bt_condicao_especial")]
        public bool BtCondicaoEspecial { get; set; }
        [Column("bt_vip")]
        public bool BtVip { get; set; }

        [ForeignKey(nameof(IdLogin))]
        [InverseProperty(nameof(TbLogin.TbCliente))]
        public virtual TbLogin IdLoginNavigation { get; set; }
    }
}
