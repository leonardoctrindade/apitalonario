using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Pais
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Required]
        public string Nome { get; set; }

        [Column("CodigoIbge")]
        [Required]
        public int CodigoIbge { get; set; }

        [Column("CodigoTelefonico")]
        public int CodigoTelefonico { get; set; }
    }
}
