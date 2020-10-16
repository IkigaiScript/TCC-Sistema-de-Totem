using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tb_trailer")]
    public partial class TbTrailer
    {
        [Key]
        [Column("id_trailer")]
        public int IdTrailer { get; set; }
        [Column("id_filme")]
        public int? IdFilme { get; set; }
        [Column("nm_trailer", TypeName = "varchar(100)")]
        public string NmTrailer { get; set; }
        [Column("nr_duracao")]
        public int? NrDuracao { get; set; }
        [Column("bt_dublado")]
        public bool? BtDublado { get; set; }

        [ForeignKey(nameof(IdFilme))]
        [InverseProperty(nameof(TbFilme.TbTrailer))]
        public virtual TbFilme IdFilmeNavigation { get; set; }
    }
}
