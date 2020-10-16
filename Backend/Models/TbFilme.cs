using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tb_filme")]
    public partial class TbFilme
    {
        public TbFilme()
        {
            TbAtor = new HashSet<TbAtor>();
            TbDiretor = new HashSet<TbDiretor>();
            TbSessao = new HashSet<TbSessao>();
            TbTrailer = new HashSet<TbTrailer>();
        }

        [Key]
        [Column("id_filme")]
        public int IdFilme { get; set; }
        [Column("nm_filme", TypeName = "varchar(100)")]
        public string NmFilme { get; set; }
        [Column("ds_genero", TypeName = "varchar(255)")]
        public string DsGenero { get; set; }
        [Column("ds_sinopse", TypeName = "varchar(255)")]
        public string DsSinopse { get; set; }
        [Column("ds_imagem", TypeName = "varchar(255)")]
        public string DsImagem { get; set; }
        [Column("nr_classficacao")]
        public int? NrClassficacao { get; set; }
        [Column("nr_duracao")]
        public int? NrDuracao { get; set; }
        [Column("bt_breve")]
        public bool? BtBreve { get; set; }
        [Column("bt_estreia")]
        public bool? BtEstreia { get; set; }

        [InverseProperty("IdFilmeNavigation")]
        public virtual ICollection<TbAtor> TbAtor { get; set; }
        [InverseProperty("IdFilmeNavigation")]
        public virtual ICollection<TbDiretor> TbDiretor { get; set; }
        [InverseProperty("IdFilmeNavigation")]
        public virtual ICollection<TbSessao> TbSessao { get; set; }
        [InverseProperty("IdFilmeNavigation")]
        public virtual ICollection<TbTrailer> TbTrailer { get; set; }
    }
}
