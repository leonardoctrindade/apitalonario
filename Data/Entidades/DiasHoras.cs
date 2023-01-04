using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Data.Entidades
{
    public class DiasHoras
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("DiaSemana")]
        public string DiaSemana { get; set; }

        [Column("HoraInicial")]
        public DateTime HoraInicial { get; set; }

        [Column("HoraFinal")]
        public DateTime HoraFinal { get; set; }

        [Column("Quantidade")]
        public int? Quantidade { get; set; }

        [Column("Hash")]
        public string Hash { get; set; }

        [Column("CodigoDia")]
        [Required(ErrorMessage = "Campo de código do dia não preenchido")]
        public int CodigoDia { get; set; }

        [Column("Sequencia")]
        [Required(ErrorMessage = "Campo de sequencia não preenchido")]
        public int Sequencia { get; set; }
    }
}
