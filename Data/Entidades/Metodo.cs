using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Metodo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [MaxLength(10)]
        [Required(ErrorMessage = "Campo Descricao não preenchido")]
        public string Descricao { get; set; }

        [Column("QuantidadeGotas")]
        public int? QuantidadeGotas { get; set; }

        [Column("Percentual")]
        public decimal? Percentual { get; set; }
    }
}
