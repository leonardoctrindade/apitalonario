using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entidades
{
    public class Bula
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tipo")]
        [Required(ErrorMessage = "Campo de tipo não preenchido")]
        public int Tipo { get; set; }

        [Column("LimitacaoVisual")]
        public bool LimitacaoVisual { get; set; }

        [Column("Descricao")]
        [Required(ErrorMessage = "Campo de descricao não preenchido")]
        public string Descricao { get; set; }
    }
}
