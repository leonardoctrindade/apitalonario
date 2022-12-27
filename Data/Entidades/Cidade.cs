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
        [Required(ErrorMessage = "Campo de nome não preenchido")]
        public string Nome { get; set; }

        [Column("CodigoIbge")]
        public int? CodigoIbge { get; set; }

        [Column("CodigoCfpsId")]
        public int? CodigoCfpsId { get; set; }

        [Column("CodigoSiafi")]
        public int? CodigoSiafi { get; set; }

        public Tributo CodigoCfps { get; set; }
    }
}
