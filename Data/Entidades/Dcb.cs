using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entidades
{
    public class Dcb
    {
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [Column("CodigoDcb")]
        public string CodigoDcb { get; set; }

        [Required]
        [Column("Descricao")]
        public string Descricao { get; set; }
    }
}
