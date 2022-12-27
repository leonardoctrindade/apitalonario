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
        [MaxLength(5)]
        public string HoraInicial { get; set; }

        [Column("HoraFinal")]
        [Required(ErrorMessage = "Campo de hora final não preenchido")]
        [MaxLength(5)]
        public string HoraFinal { get; set; }

        [Column("FilialId")]
        public int FilialId { get; set; }
    }
}
