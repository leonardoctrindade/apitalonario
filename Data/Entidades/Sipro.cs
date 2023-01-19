using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entidades
{
    public class Sipro
    {
        [Column("Id")]
        public int Id { get; set; }

        public int MapaReferencia { get; set; }
    }
}
