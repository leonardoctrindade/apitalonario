using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Entidades
{
    public class Turno
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("HoraInicial")]
        [Required(ErrorMessage = "Campo de hora inicial não preenchido")]
        public DateTime HoraInicial { get; set; }

        [Column("HoraFinal")]
        [Required(ErrorMessage = "Campo de hora final não preenchido")]
        public DateTime HoraFinal { get; set; }

        [Column("FilialId")]
        public int? FilialId { get; set; }
    }
}
+