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
        [Required(ErrorMessage = "Campo de nome não preenchido")]
        public string Nome { get; set; }

        [Column("CodigoIbge")]
        [Required(ErrorMessage = "Campo de código Ibge não preenchido")]
        public int CodigoIbge { get; set; }

        [Column("CodigoTelefonico")]
        public int CodigoTelefonico { get; set; }
    }
}
