using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Posologia
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Descricao")]
        [MaxLength(100)]
        [Required(ErrorMessage = "Campo descrição não preenchido")]
        public string Descricao { get; set; }

        [Column("QuantidadeCapsulasOuDoses")]
        public int QuantidadeCapsulasOuDoses { get; set; }

        [Column("Periodo")]
        public int Periodo { get; set; } = 0;
    }
}
