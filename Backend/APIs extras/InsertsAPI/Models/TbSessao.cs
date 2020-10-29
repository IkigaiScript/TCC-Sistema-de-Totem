using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsertsAPI.Models
{
    [Table("tb_sessao")]
    public partial class TbSessao
    {
        public TbSessao()
        {
            TbIngresso = new HashSet<TbIngresso>();
        }

        [Key]
        [Column("id_sessao")]
        public int IdSessao { get; set; }
        [Column("id_filme")]
        public int? IdFilme { get; set; }
        [Column("ds_tipo_sala", TypeName = "varchar(255)")]
        public string DsTipoSala { get; set; }
        [Column("nr_sala")]
        public int? NrSala { get; set; }
        [Column("vl_ingresso", TypeName = "decimal(10,2)")]
        public decimal? VlIngresso { get; set; }
        [Column("dt_horario", TypeName = "datetime")]
        public DateTime? DtHorario { get; set; }

        [ForeignKey(nameof(IdFilme))]
        [InverseProperty(nameof(TbFilme.TbSessao))]
        public virtual TbFilme IdFilmeNavigation { get; set; }
        [InverseProperty("IdSessaoNavigation")]
        public virtual ICollection<TbIngresso> TbIngresso { get; set; }
    }
}
