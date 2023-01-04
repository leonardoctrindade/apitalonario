using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entidades
{
    public class Unidade
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

        public Tipo Tipo { get; set; }

        [Column("Fator")]
        public double? Fator { get; set; }

        public List<UnidadeConversao> UnidadesConversao { get; set; } = new List<UnidadeConversao>();

    }
    public enum Tipo
    {
        Massa,
        Volume
    }
}
