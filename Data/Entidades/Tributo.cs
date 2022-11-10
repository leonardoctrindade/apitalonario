using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Tributo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tipo")]
        [Required]
        public int? Tipo { get; set; }

        [Column("Descricao")]
        [Required]
        [MaxLength(1000)]
        public string Descricao { get; set; }

        [Column("Codigo")]
        [Required]
        [MaxLength(10)]
        public string Codigo { get; set; }
    }
}
