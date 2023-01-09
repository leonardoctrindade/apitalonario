using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class HabitosCliente
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("TempoFumante")]
        [MaxLength(20)]
        public string TempoFumante { get; set; }

        [Column("Fumante")]
        public bool Fumante { get; set; }

        [Column("BebidasAlcolicas")]
        public string BebidasAlcolicas { get; set; }

        [Column("OutrosHabitos")]
        public string OutrosHabitos { get; set; }

        [Column("ClienteId")]
        [Required(ErrorMessage = "Campo de ClienteId não preenchido")]
        public int ClienteId { get; set; }
    }
}
