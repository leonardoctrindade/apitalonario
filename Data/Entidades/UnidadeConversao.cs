using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entidades
{
    public class UnidadeConversao
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Sigla")]
        [Required]
        [MaxLength(2)]
        public string Sigla { get; set; }
        [Column("Descricao")]
        [Required]
        [MaxLength(50)]
        public string Descricao { get; set; }
        //[Column("SiglaConversao")]
        //[Required]
        //[MaxLength(2)]
        //public string SiglaConversao { get; set; }
        [Column("Fator")]
        public double? Fator { get; set; }
        [Column("IdUnidade")]
        public int? IdUnidade { get; set; }
        //public List<Unidade>? Unidade { get; set; }
    }
}
