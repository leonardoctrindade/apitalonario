using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Entidades
{
    public class Cidade
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        [Required]
        public string Nome { get; set; }

        [Column("CodigoIbge")]
        public int CodigoIbge { get; set; }

        [Column("IdCodigoCfps")]
        public int IdCodigoCfps { get; set; }

        [Column("CodigoSiafi")]
        public int CodigoSiafi { get; set; }
    }
}
