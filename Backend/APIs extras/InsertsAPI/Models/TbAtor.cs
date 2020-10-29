using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InsertsAPI.Models
{
    [Table("tb_ator")]
    public partial class TbAtor
    {
        [Key]
        [Column("id_ator")]
        public int IdAtor { get; set; }
        [Column("id_filme")]
        public int? IdFilme { get; set; }
        [Column("nm_ator", TypeName = "varchar(100)")]
        public string NmAtor { get; set; }
        [Column("dt_nascimento", TypeName = "datetime")]
        public DateTime? DtNascimento { get; set; }

        [ForeignKey(nameof(IdFilme))]
        [InverseProperty(nameof(TbFilme.TbAtor))]
        public virtual TbFilme IdFilmeNavigation { get; set; }
    }
}
